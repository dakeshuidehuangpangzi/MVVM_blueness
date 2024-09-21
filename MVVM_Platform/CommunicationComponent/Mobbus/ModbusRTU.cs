
using System.Data;

namespace CommunicationComponent
{
    public class ModbusRTU:ModbusBase
    {

        SerialUnit Serial;

        public ModbusRTU(string config = "1,19200,8,1,0")
        {
            Serial=new SerialUnit(config);
        }

        //报文的发送和接收

        public void Write(List<byte> reqBytes)
        {
            CRC16(reqBytes);
            Result connectState = this.Serial.Connect();
            if (!connectState.Status)
                throw new Exception(connectState.ErrMessage);
            var result = this.Serial.SendAndReceived(reqBytes.ToArray(), 0, reqBytes.Count, 1000);
            if (result.Status)
            {
                // 五、获取响应CRC校验
                 List<byte> crcValidation =  result.Data.GetRange(0, result.Data.Count - 2);
                // 校验CRC
                this.CRC16(crcValidation);
                // 校验结果
                if (!crcValidation.SequenceEqual(result.Data))
            {
                throw new Exception("CRC校验检查不匹配");
                // CRC 校验失败
            }
                // 六、检查异常报文
                if (result.Data[1] > 0x80)
                {
                    byte errorCode = result.Data[2];
                    throw new Exception(Errors[errorCode]);
                }
            }
            else
                throw new Exception(connectState.ErrMessage);

        }
        /// <summary>
        /// 读取数据请求的方法封装
        /// </summary>
        /// <param name="slaveNum"></param>
        /// <param name="funcCode"></param>
        /// <param name="startAddr"></param>
        /// <param name="count">请求寄存器数量</param>
        /// <param name="respLen">正常响应字节数</param>
        /// <returns></returns>
        protected  List<byte> Read(byte slaveNum, byte funcCode, ushort startAddr, ushort count, ushort respLen)
        {
            // 一、组建请求报文
            List<byte> dataBytes = this.CreateReadPDU(slaveNum, funcCode, startAddr, count);
            // 二、计算关拼接CRC校验码
            CRC16(dataBytes);
            // 三、打开/检查通信组件的状态
            Result connectState = this.Serial.Connect();
            if (connectState.Status)
            {
                // 四、发送请求报文
                Result<List<byte>> resp = this.Serial.SendAndReceived(
                    dataBytes, // 发送的请求报文 
                    respLen + 5,// 正常响应字节
                    5,0); // 异常响应报文长度
                if (!resp.Status)
                    throw new Exception(resp.ErrMessage);


                // 五、校验检查
                List<byte> crcValidation = resp.Data.GetRange(0, resp.Data.Count - 2);
                this.CRC16(crcValidation);
                if (!crcValidation.SequenceEqual(resp.Data))
                {
                    throw new Exception("CRC校验检查不匹配");
                    // CRC 校验失败
                }

                // 六、检查异常报文
                if (resp.Data[1] > 0x80)
                {
                    // 
                    byte errorCode = resp.Data[2];
                    throw new Exception(Errors[errorCode]);
                }
                // 七、解析
                List<byte> datas = resp.Data.GetRange(3, resp.Data.Count - 5);
                return datas;
            }
            throw new Exception(connectState.ErrMessage);
        }

        //读取线圈状态
        //写入线圈状态
        /*一般都常用写入寄存器和读取寄存器，所以这里只实现了这两个功能*/
        //读取寄存器内容
        //写入寄存器内容
        #region 读取 
        public Result<List<bool>> ReadCoil(byte slaveNum, byte funcCode, ushort startAddr, ushort count) { 
            Result<List<bool>> result = new Result<List<bool>>();
            try
            {
                for (ushort i = 0; i < count; i += 240 * 8)
                {
                    startAddr += i;
                    ushort perCount = (ushort)Math.Min(count - i, 240 * 8);//返回最小值

                    List<byte> datas = this.Read(slaveNum, funcCode,
                        startAddr,
                        perCount,
                        (ushort)(Math.Ceiling(perCount * 1.0 / 8)));
                    result.Data.AddRange(this.ReadStatusByBytes(datas, count));
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.ErrMessage = ex.Message;
            }
            return result;
        }


        public Result<List<bool>> ReadCoils(byte slaveNum, string variable, ushort count)
        {
            byte funcCode;
            ushort startAddr;
            // 做地址解析
            this.AnalysisAddress(variable, out funcCode, out startAddr);
            return ReadCoil(slaveNum, funcCode, startAddr, count);
        }
        #endregion

        #region 写入
        public Result<bool> WriteCoil(byte slaveNum, ushort startAddr, List<bool> value)
        {
            if (value.Count == 0) return new Result<bool>(false, "写入值不能为空");
            try
            {
                List<byte> reqBytes = this.CreateWritePDU(slaveNum, 15,
                    startAddr,
                    (ushort)value.Count,
                    (byte)Math.Ceiling(value.Count * 1.0 / 8));
                List<byte> valueBytes = new List<byte>();
                int index = 0;
                for (int i = 0; i < value.Count; i++)
                {
                    //status.Count  =10   每8个一个字节
                    if (i % 8 == 0)
                        valueBytes.Add(0x00);// 初始值
                    index = valueBytes.Count - 1;

                    if (value[i])
                    {
                        byte temp = (byte)(1 << (i % 8));
                        valueBytes[index] |= temp;
                    }
                }
                reqBytes.AddRange(valueBytes);
                this.Write(reqBytes);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, ex.Message);
            }
            return new Result<bool>(true, "写入成功");
        }

        public Result<bool> WriteRegister<T>(byte slaveNum, ushort startAddr, IList<T> value)
        {
            if (value.Count == 0) return new Result<bool>(false, "写入值不能为空");
            //先获取T是什么类型，判断写入数据有多少个字节
            try
            {
                int len = Marshal.SizeOf(typeof(T));// 当前写入数据中每个数据所需要的字节数
                List<byte> reqBytes = this.CreateWritePDU(slaveNum, 16, startAddr,
                    (ushort)(len / 2 * value.Count),//需要字节数/2再成数据个数
                    (byte)(value.Count * len));
                List<byte> valueBytes = new List<byte>();
                for (int i = 0; i < valueBytes.Count; i++)
                {
                    // 获取每个数字的字节   反射？
                    dynamic v = valueBytes[i];
                    List<byte> vBytes = new List<byte>(BitConverter.GetBytes(v));
                    // 字节序，判断释放进行高低端处理
                    vBytes = this.SwitchEndianType(vBytes);
                    reqBytes.AddRange(vBytes);
                }
                this.Write(reqBytes);
            }
            catch (ArgumentException)
            {
                return new Result<bool>(false, msg: "写入数据类型不支持");
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, ex.Message);
            }
            return new Result<bool>(true, "写入成功");

        }
        #endregion
    }
}

namespace CommunicationComponent
{
    public class ModbusASCII: ModbusBase
    {
        SerialUnit Serial;

        public ModbusASCII(string config = "1,19200,8,1,0")
        {
            Serial = new SerialUnit(config);
        }

        /*
         发送的信息需要先根据传输的信息进行组合再填写进来
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes">报文信息</param>
        /// <exception cref="Exception"></exception>
        public void Write(IList<byte> bytes)
        {
            LRC(bytes);
            //添加发送报头 ：和\r\n
            var bytesStrArray = bytes.Select(b => b.ToString("X2")).ToList();//先转换成16进制的集合
            //然后再添加Ascii的头尾标识符和回车换行符
            string bytesStr = ":" + string.Join("", bytesStrArray) + "\r\n";
            //转换成ascii编码
            byte[] dataBytes = Encoding.ASCII.GetBytes(bytesStr);
            // 二、发送数据
            Result connectState = this.Serial.Connect();
            if (!connectState.Status)
                throw new Exception(connectState.ErrMessage);
            var result = this.Serial.SendAndReceived(dataBytes.ToArray(), 0, dataBytes.Count(), 1000);
            if (result.Status)
            {
                //转换响应的报文
                string asciiStr = Encoding.ASCII.GetString(result.Data.ToArray(), 0, result.Data.Count);
                List<byte> dataByte = new() ;
                for (int i = 1; i < asciiStr.Length - 2; i += 2)
                {
                    string temp = asciiStr[i].ToString() + asciiStr[i + 1].ToString();// "01"  "03"   "08"
                    dataByte.Add(Convert.ToByte(temp, 16));// byte {0x01  0x03  0x08}
                }
                // 五、获取响应CRC校验
                List<byte> crcValidation = dataByte.GetRange(0, dataByte.Count - 2);
                // 校验CRC
                this.LRC(crcValidation);
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
        protected List<byte> Read(byte slaveNum, byte funcCode, ushort startAddr, ushort count, ushort respLen)
        {
            // 一、组建请求报文
            List<byte> dataBytes = this.CreateReadPDU(slaveNum, funcCode, startAddr, count);
            // 二、计算关拼接CRC校验码
            LRC(dataBytes);
            // 三、打开/检查通信组件的状态
            Result connectState = this.Serial.Connect();
            if (connectState.Status)
            {
                // 四、发送请求报文
                Result<List<byte>> resp = this.Serial.SendAndReceived(
                    dataBytes, // 发送的请求报文 
                    respLen + 5,// 正常响应字节
                    5, 0); // 异常响应报文长度
                if (!resp.Status)
                    throw new Exception(resp.ErrMessage);


                // 五、校验检查
                List<byte> crcValidation = resp.Data.GetRange(0, resp.Data.Count - 2);
                this.LRC(crcValidation);
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
    }
}

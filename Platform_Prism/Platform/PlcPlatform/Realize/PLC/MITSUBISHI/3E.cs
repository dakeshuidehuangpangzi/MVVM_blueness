using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform
{
    public class _3E
    {

        SocketUnit Socket;
        //同一种区域类型
        private Result BatchWrite<T>(MitsubishiEnum area, string startAddr, List<T> values)
        {
            Result result = new Result();
            byte subCmd=0x01;
            //头部报文
            List<byte> bytes = new List<byte>
            {
                0x50,0x00,
                0x00,
                0xFF,
                0xFF,0x03,
                0x00,
                //上面是报文头文件 

                0x0C,0x00,  // 剩余字节长度  这个需要在组合完报文后修改
                0x0A,0x00, //监控定时器设定的数值

                0x01,0x14,// 成批写入指令
                subCmd,0x00,// 位操作     字改成0
            };
            int typeLen = 1;
            if (typeof(T) != typeof(bool))
            {
                subCmd = 0x00; // 字写入
                typeLen = Marshal.SizeOf<T>() / 2;   // 当前类型下，每个数据需要多个地址的寄存器
            }
            List<byte> startBytes = new List<byte>();
            if (!int.TryParse(startAddr, out int addr))
            {
                throw new Exception("软元件地址不支持！");
            }
            startBytes.Add((byte)(addr % 256));
            startBytes.Add((byte)(addr / 256 % 256));
            startBytes.Add((byte)(addr / 256 / 256 % 256));//起始地址

            // 起始地址
            bytes.AddRange(startBytes);
            // 区域代码
            bytes.Add((byte)area);
            // 写入长度
            ushort len = (ushort)(typeLen * values.Count());
            // 这里指的是操作的点数，与字节无关
            bytes.AddRange(BitConverter.GetBytes(len));

            // 针对位操作时的处理
            if (subCmd == 0x01)
            {
                //len = (ushort)Math.Ceiling(len * 1.0 / 2);    // 1个状态  1个字节 ；  2个状态   1个字节  ；  3个状态   2个字节    
                // { 1 ,1 ,1 ,1 ,1,0}
                // {}
                for (int i = 0; i < values.Count(); i++)
                {
                    if (i % 2 == 0)
                    {
                        bytes.Add(0x00);
                    }
                    bool state = bool.Parse(values[i].ToString());

                    if (state)
                    {
                        byte arg = 0x01;
                        if (i % 2 == 0)
                            arg *= 16;      // 按位或  0001 0000
                        bytes[bytes.Count - 1] |= arg;
                    }
                }
            }
            else
            {
                // 字节操作的时候
                foreach (dynamic item in values)
                {
                    bytes.AddRange(BitConverter.GetBytes(item));
                }
            }
            ushort bytesLen = (ushort)(bytes.Count - 9);
            bytes[7] = BitConverter.GetBytes(bytesLen)[0];
            bytes[8] = BitConverter.GetBytes(bytesLen)[1];//后面有多少个字节数


            Result<List<byte>> dataResult = Socket.SendAndReceived(bytes,11,200);
            if (!dataResult.Started)
            {
                result.Started = dataResult.Started;
                result.ErrMessage = dataResult.ErrMessage;
                return result;
            }//写入失败

            var data = dataResult.Data;

            if (data[3] != 0XFF && data[4] != 0XFF)
            {
                
            }
                return result;

        }
        /// <summary>
        /// 多块成批写入，区分字和位存储区
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="area"></param>
        /// <param name="startAddr"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private Result MultiWrite<T>(List<Parameter>parameters)
        {
            Result result = new Result();
            List<MitsubishiParameter> mitsubishis=new List<MitsubishiParameter>();
            foreach (var item in parameters)
            {
                if (item is MitsubishiParameter Mpar)
                    mitsubishis.Add(Mpar);
                else if (item is Parameter par)
                {
                    //进入转换判断
                }
                else
                {
                    result.Started = false;
                    result.ErrMessage = "输入参数类型错误,请确认";
                    return result;
                }
            }

            ushort num = (ushort)(mitsubishis.Count * 6 + 8);
            List<byte> bytes = new List<byte>
                {
                    0x50,0x00,
                    0x00,
                    0xFF,
                    0xFF,0x03,
                    0x00
                };
            // 后续字节数
            bytes.AddRange(BitConverter.GetBytes(num));
            // PLC处理超时时间
            bytes.AddRange(new byte[] { 0x0A, 0x00 });
            // 主操作码
            bytes.AddRange(new byte[] { 0x06, 0x04 });
            // 子操作码
            bytes.AddRange(new byte[] { 0x00, 0x00 });

            // 计算两种类型的处理块数
            bytes.Add(BitConverter.GetBytes(mitsubishis.Count(s => !s.IsSecond))[0]);// 拼接字处理点数
            bytes.Add(BitConverter.GetBytes(mitsubishis.Count(s => s.IsSecond))[0]);// 拼接双字处理点数 

            List<MitsubishiParameter> sortList = mitsubishis.OrderBy(p => p.IsSecond).ToList();
            foreach (var item in sortList)
            {
                List<byte> startBytes = new List<byte>();
                if (item.Area == MitsubishiEnum.X || item.Area == MitsubishiEnum.Y)
                {
                    string str = item.StartArea.ToString().PadLeft(6, '0');
                    for (int i = 0; i < 6; i += 2)
                    {
                        string a = str[i].ToString() + str[i + 1].ToString();
                        startBytes.Add(Convert.ToByte(a, 16));
                    }
                    startBytes.Reverse();
                }
                else
                {
                    startBytes.Add((byte)(item.StartArea % 256));
                    startBytes.Add((byte)(item.StartArea / 256 % 256));
                    startBytes.Add((byte)(item.StartArea / 256 / 256 % 256));
                }

                bytes.AddRange(startBytes);// 当前一个地址的起始位置
                bytes.Add((byte)item.Area);// 添加存储区编号

                // Count  ：数据个数，不是地址个数   不是点数，与类型相关
                // 例：ushort  1       float    1
                //      D   1                   2    2个地址
                //      X   1                   2    32个地址
                // X0  开始请求一个点：随机、多块成批     16个位    X0-XF    X0-X7  X10-X17
                //                     成批：一个点就是一个位
                // M0  开始请求一个点：随机、多块成批     M0-M16
                ushort len = (ushort)(Marshal.SizeOf(item.DataType) / 2 * item.Count);
                bytes.AddRange(BitConverter.GetBytes(len));// 区分D  字区   X  位区   不需要
            }






            return result;

        }

    }
}

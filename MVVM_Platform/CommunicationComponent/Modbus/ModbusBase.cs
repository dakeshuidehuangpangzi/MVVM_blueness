
using System.Data;

namespace CommunicationComponent
{
    public abstract class ModbusBase
    {
        protected static Dictionary<int, string> Errors = new Dictionary<int, string>
        {
            { 0x01, "非法功能码"},
            { 0x02, "非法数据地址"},
            { 0x03, "非法数据值"},
            { 0x04, "从站设备故障"},
            { 0x05, "确认，从站需要一个耗时操作"},
            { 0x06, "从站忙"},
            { 0x08, "存储奇偶性差错"},
            { 0x0A, "不可用网关路径"},
            { 0x0B, "网关目标设备响应失败"},
        };


        public EndianType EndianType { get; set; } = EndianType.AB;

        /// <summary>
        /// 写报文内容填充,只填充功能码、起始地址、数据长度  数据需要自己添加
        /// </summary>
        /// <param name="slaveNum">站号</param>
        /// <param name="funcCode">功能码</param>
        /// <param name="count">数量</param>
        /// <param name="len">数据长度</param>
        /// <returns></returns>
        protected List<byte> CreateWritePDU(byte slaveNum, byte funcCode, ushort startAddr,  ushort count, byte len)
        {
            List<byte> command = new();
            command.Add(slaveNum);
            command.Add(funcCode);
            command.Add(BitConverter.GetBytes(startAddr)[1]);
            command.Add(BitConverter.GetBytes(startAddr)[0]);
            // 写数量
            command.Add((byte)(count / 256));
            command.Add((byte)(count % 256));

            command.Add(len);
            return command;
        }
        /// <summary>
        /// 读报文内容填充
        /// </summary>
        /// <param name="slaveNum">站号</param>
        /// <param name="funcCode">功能码</param>
        /// <param name="startAddr">起始地址</param>
        /// <param name="count">数量</param>
        /// <returns></returns>

        protected List<byte> CreateReadPDU(byte slaveNum, byte funcCode, ushort startAddr, ushort count)
        {
            List<byte> datas = new ();
            datas.Add(slaveNum);
            datas.Add(funcCode);

            datas.Add((byte)(startAddr / 256));
            datas.Add((byte)(startAddr % 256));

            datas.Add((byte)(count / 256));
            datas.Add((byte)(count % 256));

            return datas;
        }
        /// <summary>
        /// 表示将一个数据字节进行指定字节序的调整
        /// </summary>
        /// <param name="bytes">接收待转换的设备中返回的字节数组</param>
        /// <returns>返回调整完成的字节数组</returns>
        public List<byte> SwitchEndianType(IList<byte> bytes)
        {
            // 不管是什么字节序，这个Switch里返回的是ABCD这个顺序
            List<byte> temp = new List<byte>();
            switch (EndianType)  // alt+enter
            {
                case EndianType.AB:
                case EndianType.ABCD:
                case EndianType.ABCDEFGH:
                    temp = (List<byte>)bytes;
                    break;
                case EndianType.BA:
                case EndianType.DCBA:
                case EndianType.HGFEDCBA:
                    for (int i = bytes.Count - 1; i >= 0; i--)
                    {
                        temp.Add(bytes[i]);
                    }
                    //temp = new List<byte> { bytes[1], bytes[0] };
                    break;
                case EndianType.CDAB:
                    temp = new List<byte> { bytes[2], bytes[3], bytes[0], bytes[1] };
                    break;
                case EndianType.BADC:
                    temp = new List<byte> { bytes[1], bytes[0], bytes[3], bytes[2] };
                    break;
                //case EndianType.DCBA:
                //    temp = new List<byte> { bytes[3], bytes[2], bytes[1], bytes[0] };
                //    break;
                case EndianType.GHEFCDAB:
                    temp = new List<byte> { bytes[6], bytes[7], bytes[4], bytes[5], bytes[2], bytes[3], bytes[0], bytes[1] };
                    break;
                case EndianType.BADCFEHG:
                    break;
            } 
            if (BitConverter.IsLittleEndian)
                temp.Reverse();

            return temp;
        }


        public List<bool> ReadStatusByBytes(List<byte> dataBytes, int count)
        {
            List<bool> result = new List<bool>();
            int sum = 0;
            for (int j = 0; j < dataBytes.Count; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    // 遍历每个字节中的每个位
                    byte temp = (byte)(1 << k);
                    result.Add((dataBytes[j] & temp) != 0);
                    // 
                    sum++;
                    if (sum == count)
                        break;
                }
            }
            return result;
        }
        protected void AnalysisAddress(string address, out byte fc, out ushort sa)
        {
            fc = 0;
            switch (address[0])
            {
                case '0':
                    fc = 1;
                    break;
                case '1':
                    fc = 2;
                    break;
                case '3':
                    fc = 4;
                    break;
                case '4':
                    fc = 3;
                    break;
            }
            sa = (ushort)(ushort.Parse(address.Substring(1)) - 1);
        }


        #region 校验

        /// <summary>
        /// 计算CRC校验码
        /// </summary>
        /// <param name="value"></param>
        /// <param name="poly"></param>
        /// <param name="crcInit"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected void CRC16(IList<byte> value, ushort poly = 0xA001, ushort crcInit = 0xFFFF)
        {
            if (value == null || !value.Any())
                throw new ArgumentException("");

            //运算
            ushort crc = crcInit;
            for (int i = 0; i < value.Count; i++)
            {
                crc = (ushort)(crc ^ (value[i]));
                for (int j = 0; j < 8; j++)
                {
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ poly) : (ushort)(crc >> 1);
                }
            }
            byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
            byte lo = (byte)(crc & 0x00FF);         //低位置

            value.Add(lo);
            value.Add(hi);
        }
        protected void LRC(IList<byte> value)
        {
            if (value == null) return;

            int sum = 0;
            for (int i = 0; i < value.Count; i++)
            {
                sum += value[i];
            }

            sum = sum % 256;
            sum = 256 - sum;

            value.Add((byte)sum);// 16进制一个字节
        }
        #endregion
    }
}

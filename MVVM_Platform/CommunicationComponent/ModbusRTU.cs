using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponent
{
    public class ModbusRTU:ModbusBase
    {

        SerialUnit Serial;

        public ModbusRTU(string config = "1,19200,8,1,0")
        {
            Serial=new SerialUnit(config);
        }


        public void Write(byte slaveNum, byte funcCode, ushort startAddr, byte[] data, ushort respLen)
        {
            List<byte> dataBytes = this.CreateWritePDU(slaveNum, funcCode, startAddr, data);
            CRC16(dataBytes);
            Result connectState = this.Serial.Connect();
            if (!connectState.Status)
                throw new Exception(connectState.ErrMessage);


        }



        /// <summary>
        /// 计算CRC校验码
        /// </summary>
        /// <param name="value"></param>
        /// <param name="poly"></param>
        /// <param name="crcInit"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        void CRC16(List<byte> value)
        {
            if (value == null || !value.Any())
                throw new ArgumentException("");
            //运算
            ushort crc = 0xFFFF;
            ushort poly = 0xA001;
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
    }
}

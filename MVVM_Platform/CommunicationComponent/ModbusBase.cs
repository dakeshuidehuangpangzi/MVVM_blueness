using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponent
{
    public class ModbusBase
    {

        /// <summary>
        /// 写报文内容填充
        /// </summary>
        /// <param name="slaveNum">站号</param>
        /// <param name="funcCode">功能码</param>
        /// <param name="startAddr">起始地址</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected List<byte> CreateWritePDU(byte slaveNum, byte funcCode, ushort startAddr, byte[] data)
        {
            List<byte> command = new List<byte>();
            command.Add(slaveNum);
            command.Add(funcCode);
            command.Add(BitConverter.GetBytes(startAddr)[1]);
            command.Add(BitConverter.GetBytes(startAddr)[0]);

            if (funcCode == 0x10)// 写多寄存器
            {
                // 写寄存器数量
                command.Add(BitConverter.GetBytes(data.Length / 2)[1]);
                command.Add(BitConverter.GetBytes(data.Length / 2)[0]);
                // 要写入寄存器的字节数
                command.Add((byte)data.Length);
            }
            command.AddRange(data);

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
            List<byte> datas = new List<byte>();
            datas.Add(slaveNum);
            datas.Add(funcCode);

            datas.Add((byte)(startAddr / 256));
            datas.Add((byte)(startAddr % 256));

            datas.Add((byte)(count / 256));
            datas.Add((byte)(count % 256));

            return datas;
        }


    }
}

using Kvaser.CanLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform.Realize.Can
{
    public static class CANDLL
    {
        /*Kvaser.CanLib仅支持32位，需要单独创建一个DLL，并且是以X86编译*/


        [DllImport("coredll.dll")]
        static extern int CloseHandle(uint hDevice);
        [DllImport("CAN_API_DLL.dll")]
        public static extern int CAN_();
        //[DllImport("CANDLL.dll", EntryPoint = "CanOpen", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int CanOpen(string szDevName, int dwBaudRate, int dwMode);
        public static void CANDLL1()
        {
            Canlib.canInitializeLibrary(); //初始化canlib库
            int Handle=Canlib.canOpenChannel(0, Canlib.canOPEN_ACCEPT_VIRTUAL); //打开can通道
            Canlib.canSetBitrate(Handle, Canlib.canBITRATE_500K); //设置波特率
            Canlib.canBusOn(Handle); //使能can总线
            byte[] msg = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };


            // 发送
            // Canlib.canWrite(handle, 13, msg, 0, 2);  // 13表示的对方的ID    对方节点进行
            // Flag:1:表示远程请求
            //      2:11位ID的标准帧 
            //      3:29位ID的扩展帧

            // 接收 - 广播  
            Canlib.canRead(Handle, out int MsgCount, msg, out int dlc, out int flags, out long timeStamp); //读取can数据
            // 接收 - 指定   
            //Canlib.canReadSpecific(handle, 13, msg, out int dlc, out int flag, out long time);


            Console.WriteLine("收到can数据：{0}", BitConverter.ToString(msg));
            //Canlib.canClose(Handle); //关闭can通道
            //Canlib.canUnloadLibrary(); //释放canlib库
        }
    }
}

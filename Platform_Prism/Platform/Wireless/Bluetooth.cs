using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using Linux.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Wireless
{
    public class Bluetooth
    {
        public Bluetooth()
        {
            BluetoothClient client = new BluetoothClient();

            //广域搜索可找到的蓝牙设备
            var deviceInfos = client.DiscoverDevices().ToList();
            foreach (var device in deviceInfos)
            {
                Console.WriteLine($"{device.DeviceName}------{device.DeviceAddress}");
            }

            //匹配 00001101-0000-1000-8000-00805f9b34fb 
            client.Connect(deviceInfos[0].DeviceAddress, BluetoothService.Handsfree);



            //接收图片
            //远程存储图片文件名称
            ObexWebRequest request = new ObexWebRequest(deviceInfos[0].DeviceAddress, "1690012616281.jpg");

            request.ReadFile("D:\\1690012616281.jpg");
            WebResponse response = request.GetResponse();
            response.Close();

        }


        public void BlueToothServer()
        {
            BluetoothListener listener = new BluetoothListener(BluetoothService.SerialPort);
            listener.Start();
            Console.WriteLine($"开始监听------");
            BluetoothClient client = listener.AcceptBluetoothClient();
            NetworkStream stream = client.GetStream();
            byte[] bytes = new byte[5];
            stream.Read(bytes);
            Console.WriteLine($"读取到{string.Join(" ",bytes.Select(x=>x.ToString("X2")))}");
            byte[] bytes1 = new byte[5];
            stream.Write(bytes1);
            stream.Close();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform
{
    public class SocketUnit : CommunicationBase
    {
        protected Socket socket;
        public string IP="192.168.3.39";
        public int Port = 6002;

        public override Result Close()
        {
           if (socket != null) socket.Close();
            return new Result();
        }
        ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public override Result Connect(int trycount = 20)
        {
            Result result = new Result();
            try
            {
                if (socket == null)
                    // ProtocolType 可支持配置
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                int count = 0;
                bool connectState = false;
                TimeoutObject.Reset();
                while (count < trycount)
                {
                    if (!(!socket.Connected || (socket.Poll(200, SelectMode.SelectRead) && (socket.Available == 0))))
                    {
                        return result;
                    }
                    try
                    {
                        socket?.Close();
                        socket.Dispose();
                        socket = null;

                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socket.BeginConnect(IP, Port, callback =>
                        {
                            connectState = false;
                            var cbSocket = callback.AsyncState as Socket;
                            if (cbSocket != null)
                            {
                                connectState = cbSocket.Connected;

                                if (cbSocket.Connected)
                                    cbSocket.EndConnect(callback);

                            }
                            TimeoutObject.Set();
                        }, socket);
                        TimeoutObject.WaitOne(2000, false);
                        if (!connectState) throw new Exception();
                        else break;
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.TimedOut)// 连接超时
                            throw new Exception(ex.Message);
                    }
                    catch (Exception) { }
                }
                if (socket == null || !socket.Connected || ((socket.Poll(200, SelectMode.SelectRead) && (socket.Available == 0))))
                {
                    throw new Exception("网络连接失败");
                }
            }
            catch (Exception ex)
            {
                result = new Result(false, ex.Message);
            }
            return result;
        }

        public override void Read(IEnumerable<object> value, Func<object> CallBack)
        {

        }

        public override Result<List<byte>> SendAndReceived(IEnumerable<byte> req, int len1, int timeout, Func<byte[], int> calcLen = null)
        {
            Result<List<byte>> result = new Result<List<byte>>();
            try
            {
                socket.ReceiveTimeout = timeout;

                if (req != null)
                    socket.Send(req.ToArray(), 0, req.Count(), SocketFlags.None);

                // 获取报文头字节
                byte[] data = new byte[len1];
                socket.Receive(data, 0, len1, SocketFlags.None);
                result.Data = new List<byte>(data);

                int dataLen = 0;
                if (calcLen != null)
                    dataLen = calcLen(data);
                if (dataLen == 0)
                    throw new Exception("获取数据长度失败");

                // 剩余的报文字节
                data = new byte[dataLen];
                socket.Receive(data, 0, dataLen, SocketFlags.None);
                result.Data = new List<byte>(data);
            }
            catch (SocketException se)
            {
                result.Started = false;
                if (se.SocketErrorCode == SocketError.TimedOut)
                {
                    result.ErrMessage = "未获取到响应数据，接收超时";
                }
            }
            catch (Exception ex)
            {
                result.Started = false;
                result.ErrMessage = ex.Message;
            }
            return result;
        }

        public override bool Write(IEnumerable<object> value)
        {
            return false;
        }
    }
}

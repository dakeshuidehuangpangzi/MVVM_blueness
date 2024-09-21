
namespace CommunicationComponent
{
    public  class SocketUnit : AbsUnit
    {
        readonly object trans_lock = new object();
        Socket socket;
        
        string host;
        int port;
        public SocketUnit(string config="192.169.10.1,520" )
        {
            var con = config.Split(',');
            host = con[0];
            port=int.Parse(con[1]);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
     

        public override Result Connect() 
        {
            lock (trans_lock)
            {
                if (socket==null)
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    if (socket.Connected)  return new Result();
                    socket?.Close();
                    socket.Dispose();
                    socket = null;
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //异步连接
                    socket.Connect(host, port);
                    if (!socket.Connected) return new Result(false,$"连接失败");
                    return new Result();
                }
                catch (Exception ex)
                {
                    return new Result(false,ex.Message);
                }

            }
        }
        /// <summary>
        /// 异步连接
        /// </summary>
        /// <param name="tryCont"></param>
        public override void BeginConnect(int tryCont = 30)
        {
            lock (trans_lock)
            {
                if (socket == null)
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    if (socket.Connected) return;
                    TimeoutObject.Reset();
                    bool connectStart = false;
                    while (true)
                    {
                        socket?.Close();
                        socket.Dispose();
                        socket = null;
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        //异步连接
                        socket.BeginConnect(host, port, callback => {
                            connectStart = false;
                            var callsocket = callback.AsyncState as Socket;
                            if (callback != null)
                            {
                                connectStart = callsocket.Connected;
                                if (callsocket.Connected)
                                {
                                    callsocket.EndConnect(callback);
                                }
                            }
                            TimeoutObject.Set();
                        }, socket);
                        TimeoutObject.WaitOne(2000, false);
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        //断开连接
        public override void Close()
        {
            socket?.Close();
            socket?.Dispose();
        }
    }
}

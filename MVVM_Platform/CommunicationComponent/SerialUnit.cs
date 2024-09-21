namespace CommunicationComponent
{
    public  class SerialUnit: AbsUnit
    {
        readonly object trans_lock = new object();
        //串口对象
        SerialPort serialPort;

        public SerialUnit(string config="1,19200,8,1,0")
        {
            serialPort = new SerialPort();
            var con= config.Split(',');
            serialPort.PortName = $"Com{con[0]}";
            serialPort.BaudRate = int.Parse(con[1]);
            serialPort.DataBits = int.Parse(con[2]);
            serialPort.Parity = (Parity)(int.Parse(con[3])) ;
            serialPort.StopBits = (StopBits)(int.Parse(con[4]));
        }

        public override void BeginConnect(int tryCont = 30)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override Result Connect()
        {
            lock (trans_lock) 
            {
                try
                {
                    if (serialPort==null) return new Result(false, "串口未初始化");
                    if (serialPort.IsOpen) return new Result(true,"串口已打开");
                    serialPort?.Close();
                    serialPort .Open();
                    if (!serialPort.IsOpen) return new Result(false, "打开失败");
                    return new Result();
                }
                catch (Exception ex)
                {

                    return new Result(false, ex.Message);
                }


            }
        }
    }
}

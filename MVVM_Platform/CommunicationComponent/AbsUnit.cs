
namespace CommunicationComponent
{
    public abstract class AbsUnit
    {
        public abstract Result Connect();
        public abstract void BeginConnect(int tryCont = 30);
        public abstract void Close();
        internal virtual Result<List<byte>> SendAndReceived(IList<byte> req, int len1, int len2, int timeout) => null;
        //连接
        public  ManualResetEvent TimeoutObject = new ManualResetEvent(false);
    }
}

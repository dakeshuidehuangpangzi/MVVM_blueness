using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform
{
    public class SerialUnit : CommunicationBase
    {
        protected SerialPort Serial;

        public override Result Close()
        {
            if (Serial != null) 
                Serial.Close();
            return new Result();
        }

        public override Result Connect(int trycount=20)
        {
            Result result = new Result();
            int count = 0;
            try
            {
                while (count<trycount) 
                {
                    if (Serial.IsOpen) break;
                    try
                    {
                        Serial.Open();
                        break;
                    }
                    catch (IOException ex)
                    {
                        Task.Delay(1).GetAwaiter().GetResult();
                        count++;
                    }
                }
                if (Serial == null | !Serial.IsOpen)
                    throw new Exception("串口打开失败");
                ConnectState = true;
            }
            catch (Exception ex)
            {
                result.Started = false;
                result.ErrMessage = ex.Message;
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
                if (!Serial.IsOpen)
                    if (!Connect().Started) throw new Exception("连接串口失败");
                Serial.ReadTimeout = timeout;
                Serial.Write(req.ToArray(), 0, req.Count());
                List<byte> data = new List<byte>();
                try
                {
                    int readNumber = Serial.BytesToRead;
                    if (readNumber > 0)
                    {
                        byte[] _TmpData = new byte[readNumber];
                        Serial.Read(_TmpData, 0, readNumber);
                        data.AddRange(_TmpData);
                    }
                    else
                        throw new Exception("接收返回数据失败");
                }
                catch (TimeoutException )
                {
                    result.Started = false;
                    result.ErrMessage = "接收报文超时";
                }
                catch ( Exception ex)
                {
                    result.Started = false;
                    result.ErrMessage = ex.Message;
                }
                finally
                {
                    result.Data = data;
                }
            }
            catch (Exception ex )
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

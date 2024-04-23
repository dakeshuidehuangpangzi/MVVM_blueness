using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponent
{
    public  class Result 
    {
        public string ErrMessage { get; set; } = "";

        public bool Status { get; set; } = true;
        public Result(bool status, string errMessage)
        {
            ErrMessage = errMessage;
            Status = status;
        }
        public Result() : this(true, "") { }
    }

    public  class Result<T> : Result
    {
        public T Data { get; set; }

        public Result() : this(true, "OK") { }

        public Result(bool state, string msg) : this(state, msg, default) { }

        public Result(bool state, string msg, T data)
        {
            this.Status = state; ErrMessage = msg; Data = data;
        }
    }
}

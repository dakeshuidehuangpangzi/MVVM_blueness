using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform
{
    public class Result
    {
        public bool Started { get; set; }

        public string ErrMessage { get; set; }
        public Result(bool starte,string err)
        {
            Started= starte;
            ErrMessage= err;
        }
        public Result() : this(true, "") { }
    }

    public class Result<T>:Result
    {
        public T Data { get; set; }

        public Result() : this(true, "") { }

         public Result(bool state, string msg) : this(state, msg, default(T)) { }

        public Result(bool started,string errMessage,T data)
        {
            Started= started;
            ErrMessage= errMessage;
            Data= data;
        }
    }
}

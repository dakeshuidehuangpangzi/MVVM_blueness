﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponent
{
    public class ErrMessageArg:EventArgs
    {
        public string Errmessage { get; internal set; }

        public Exception Exception { get; internal set; }
    }
}

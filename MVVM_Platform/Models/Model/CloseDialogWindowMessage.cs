using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CloseDialogWindowMessage
    {
        public WeakReference? Sender { get; set; }


        public bool Close { get; set; }
    }
}

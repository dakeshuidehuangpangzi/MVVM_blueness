using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform
{
    public class MitsubishiParameter:Parameter
    {
        /// <summary>区域</summary>
        public MitsubishiEnum Area { get; set; }
        /// <summary>起始地址</summary>
        public int StartArea { get; set; }
        /// <summary>区域进制</summary>
        public bool IsHexArea { get; set; } = false;
        /// <summary>字true/位false</summary>
        public bool IsSecond { get; set; } = false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform
{
    public class Parameter
    {
        /// <summary>变量名称</summary>
        public string Name { get; set; }="" ;
        /// <summary>地址</summary>
        public string AddressName { get; set; } = "";
        /// <summary>参数值</summary>
        public object  Value { get; set; }
        /// <summary>数量</summary>
        public ushort Count { get; set; } = 0;
        /// <summary>数据类型</summary>
        public Type DataType { get; set; }=typeof(int);
        /// <summary>设置设备类型</summary>
        public MachineType MachineType { get; set; }
        public string MachineName { get; set; } = "";

        /// <summary>连续性读取使用</summary>
        public List<object> Datas { get; set; } = new List<object>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlcPlatform
{
    public class CheckParameter
    {

        public static object Check(Parameter parm)
        {
            if (parm.MachineType == MachineType.Mitsubishi) return CheckMitsubishi(parm);
            else if (parm.MachineType == MachineType.Siemens) return CheckSiemens(parm);
            else
                throw new Exception("转换异常");
        }

        static MitsubishiParameter CheckMitsubishi(Parameter parm)
        {
            parm.AddressName.ToUpper();
            MitsubishiParameter returnparm = new MitsubishiParameter() {
                AddressName = parm.AddressName,
                MachineType = parm.MachineType,
                DataType = parm.DataType,
                MachineName = parm.MachineName,
                Name = parm.Name,

            };
            string en=parm.AddressName.ToUpper().Substring(0, 1);
            if (en =="S")
            {
                if (parm.AddressName.ToUpper().Substring(0, 2)== "SB")
                {
                    returnparm.Area = MitsubishiEnum.SB;
                    returnparm.IsHexArea = true;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(2, parm.AddressName.Length - 2));
                }
                else if (parm.AddressName.ToUpper().Substring(0, 2) == "SW")
                {
                    returnparm.Area = MitsubishiEnum.SW;
                    returnparm.IsHexArea = true;
                    returnparm.IsSecond = true;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(2, parm.AddressName.Length - 2));
                }
                else
                {
                    returnparm.Area = MitsubishiEnum.S;
                    returnparm.IsSecond = true;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(1, parm.AddressName.Length - 1));
                }
            }
            else if (en =="Z")
            {
                if (parm.AddressName.ToUpper().Substring(0, 2) == "ZR")
                {
                    returnparm.Area = MitsubishiEnum.ZR;
                    returnparm.IsSecond = true;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(2, parm.AddressName.Length - 2));
                }
                else
                {
                    returnparm.Area = MitsubishiEnum.Z;
                    returnparm.IsSecond = false;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(1, parm.AddressName.Length - 1));
                }
            }
            else
            {
                var areas = Enum.GetValues(typeof(MitsubishiEnum));
                foreach (var item in areas)
                {
                    if (item.ToString() == en)
                    {
                        returnparm.Area = (MitsubishiEnum)item;
                        returnparm.IsSecond = MitsubishiIsSecond(en);
                        returnparm.IsHexArea = MitsubishiIsHexArea(en);
                        returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(1, parm.AddressName.Length - 1));
                        break;
                    }
                }
            }
            return returnparm;
        }
        static MitsubishiParameter CheckSiemens(Parameter parm)
        {
            parm.AddressName.ToUpper();
            MitsubishiParameter returnparm = new MitsubishiParameter();
            string en = parm.AddressName.ToUpper().Substring(0, 1);
            if (en == "S")
            {
                returnparm = (MitsubishiParameter)parm;

                if (parm.AddressName.ToUpper().Substring(0, 2) == "SB")
                {
                    returnparm.Area = MitsubishiEnum.SB;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(2, parm.AddressName.Length - 2));
                }
                else if (parm.AddressName.ToUpper().Substring(0, 2) == "SW")
                {
                    returnparm.Area = MitsubishiEnum.SW;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(2, parm.AddressName.Length - 2));
                }
                else
                {
                    returnparm.Area = MitsubishiEnum.S;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(1, parm.AddressName.Length - 1));
                }
            }
            else if (en == "Z")
            {
                returnparm = (MitsubishiParameter)parm;
                if (parm.AddressName.ToUpper().Substring(0, 2) == "ZR")
                {
                    returnparm.Area = MitsubishiEnum.ZR;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(2, parm.AddressName.Length - 2));
                }
                else
                {
                    returnparm.Area = MitsubishiEnum.Z;
                    returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(1, parm.AddressName.Length - 1));
                }
            }
            else
            {
                //循环遍历
                var areas = Enum.GetValues(typeof(MitsubishiEnum));
                returnparm = (MitsubishiParameter)parm;
                foreach (var item in areas)
                {
                    if (item.ToString() == en)
                    {
                        returnparm.Area = (MitsubishiEnum)item;
                        returnparm.StartArea = Convert.ToInt32(parm.AddressName.ToUpper().Substring(1, parm.AddressName.Length - 1));
                        break;
                    }
                }

            }
            return returnparm;
        }

        static bool MitsubishiIsSecond(string address)
        {
            string[] word =new string[] { "D","SW","ZR","W","R"};
            if (word.Contains(address)) return true;
            else return false;

        }
        static bool MitsubishiIsHexArea(string address)
        {
            string[] word = new string[] { "X", "Y", "B", "W","SB","SW" };
            if (word.Contains(address)) return true;
            else return false;

        }

    }
}

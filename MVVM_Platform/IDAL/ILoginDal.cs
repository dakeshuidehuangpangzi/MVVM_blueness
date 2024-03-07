using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ILoginDal
    {
        Task<string> Login(string username, string password);

        Task<string>GetALL();
    }
}

using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface ILoginBLL
    {
        Task<UserEntity> Login(string un, string pwd);
    }

}

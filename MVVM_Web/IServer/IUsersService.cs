using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServer
{
    public interface IUsersService:IBaseService
    {
        public List<UserModel> GetAllUser();
        bool Login(string username, string pwd, out UserModel userModel);

    }
}

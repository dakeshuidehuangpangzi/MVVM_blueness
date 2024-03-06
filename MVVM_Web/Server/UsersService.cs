using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IServer;
using Models;

namespace Server
{
    public class UsersService : BaseService,IUsersService
    {
        public UsersService(IDbContext dbConfig) : base(dbConfig)
        {
        }

        public List<UserModel> GetAllUser()
        {
            return (from menu in dbContext.Set<UserModel>() select menu).ToList();
        }
    }
}

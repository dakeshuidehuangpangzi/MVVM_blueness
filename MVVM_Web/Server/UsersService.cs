using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public bool Login(string username, string pwd, out UserModel userModel)
        {
            //string password = GetMD5Str(GetMD5Str(pwd) + "|" + username);

            var users = this.Query<UserModel>(u => u.Name == username && u.Password == pwd).ToList();
            userModel = users.FirstOrDefault();

            //if (users.Count > 0 && this.AuthentationToken(username, out string token))
            //    userModel.Token = token;

            return users.Any();
        }
        private string GetMD5Str(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) return "";

            byte[] result = Encoding.Default.GetBytes(inputStr);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        }

    }
}

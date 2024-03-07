using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDal : WebDataAccess, ILoginDal
    {
        public Task<string> GetALL()
        {
            return this.GetDatas("api/GetAllUser");
        }

        public Task<string> Login(string username, string password)
        {
            //请求数据接口API
            // _webDataAccess.Post();
            // HttpContent  键值对
            Dictionary<string, HttpContent> GetFormData = new Dictionary<string, HttpContent>();

            //注意  GetFormData的Key值 需要与服务端的LoginController类里面方法Post的输入参数定义的名称一致才行
            GetFormData.Add("username", new StringContent(username));
            GetFormData.Add("password", new StringContent(password));

            //this值的是WebDataAccess这个对象
            return this.PostDatas("api/User", this.GetFormData(GetFormData));
        }
    }
}

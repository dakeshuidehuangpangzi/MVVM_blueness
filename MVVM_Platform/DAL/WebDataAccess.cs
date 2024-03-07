using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class WebDataAccess : ObservableObject,IWebDataAccess
    {
        readonly string baseUrl = "https://localhost:5001";

        [ObservableProperty]
        public GlobalValue _globalValue;

        public async Task<string> GetDatas(string url, bool isUseBase = true)
        {
            using (var client = new HttpClient())
            {
                if (GlobalValue.UserInfo != null && !string.IsNullOrEmpty(GlobalValue.UserInfo.token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _globalValue.UserInfo.token);
                }
                if (isUseBase)
                    client.BaseAddress = new Uri(baseUrl);
                var resp = client.GetAsync(url).GetAwaiter().GetResult();
                return await resp.Content.ReadAsStringAsync();
            }

        }

        public MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));

            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");

            // "{\"username\":\"admin\",\"password\":\"123456\"}"

            foreach (var item in contents)
            {
                // 需要进行传递的键值对：比如 ：username=admin
                postContent.Add(item.Value, item.Key);
            }

            return postContent;
        }

        public async Task<string> PostDatas(string url, HttpContent content, bool isUseBase = true)
        {
            using (var client = new HttpClient())// Http   Header   Body
            {
                if (isUseBase)
                    client.BaseAddress = new Uri(baseUrl);
                // 添加鉴权Token
                //if (GlobalValue.UserInfo != null && !string.IsNullOrEmpty(GlobalValue.UserInfo.token))
                //{
                //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _globalValue.UserInfo.token);
                //    // 提交数据、修改数据   需要
                //    // 查询   
                //}

                var resp = await client.PostAsync(url, content);
                //resp.IsSuccessStatusCode
                return await resp.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="prograssChanged"></param>
        /// <param name="completed"></param>
        /// <param name="headers"></param>
        public void Upload(string url, string file, Action<int> prograssChanged, Action completed, Dictionary<string, object> headers = null)
        {
            //HttpWebRequest httpWebRequest= HttpWebRequest.CreateHttp(url);  多文件上传
            //    分组上传    2000M   
            //  请求大小

            using (WebClient client = new WebClient())//
            {
                client.Headers.Add("Authorization", "Bearer" + _globalValue.UserInfo.token);//这里是添加鉴权Token


                client.UploadProgressChanged += (se, ev) => prograssChanged(ev.ProgressPercentage);
                client.UploadFileCompleted += (se, ev) => completed();

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.Headers.Add(item.Key, item.Value.ToString());
                    }
                }
                //new Uri(baseUrl + url)路径
                client.UploadFileAsync(new Uri(baseUrl + url), "POST", file);
            }
        }
    }
}

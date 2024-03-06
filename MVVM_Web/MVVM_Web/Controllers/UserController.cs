using IServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Models;
using System.Linq;

namespace MVVM_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService=usersService;
        }

        [HttpGet("GetAllUser")]
        //[Authorize]//添加这个后，相应授权才能进入该方法
        public IActionResult GetAllUser()
        {
            List<UserModel> result = new List<UserModel>();
            try
            {
                var datas = _usersService.GetAllUser();

                result.AddRange(datas);
                //result.Data = datas;// _menuService.GetAllMenus(); ;
            }
            catch (Exception ex)
            {
                //result.State = 500;
                //result.ExceptionMessage = ex.Message;
            }

            return Ok(result);
        }


        [HttpGet("GetAllType")]
        //[Authorize]//添加这个后，相应授权才能进入该方法
        public IActionResult GetAllType()
        {
            List<GoodModel> result = new List<GoodModel>();
            try
            {
                var datas = this._usersService.Query<GoodModel>(mm => mm.GId != "").ToList();

                result.AddRange(datas);
                //result.Data = datas;// _menuService.GetAllMenus(); ;
            }
            catch (Exception ex)
            {
                //result.State = 500;
                //result.ExceptionMessage = ex.Message;
            }

            return Ok(result);
        }
    }
}

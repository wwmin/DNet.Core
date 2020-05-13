using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNet.Core.AuthHelper;
using DNet.Core.Common;
using DNet.Core.IServices;
using DNet.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quartz.Impl.Triggers;

namespace DNet.Core.Controllers
{
    /// <summary>
    /// 登录相关
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        readonly ISysUserInfoServices _sysUserInfoServices;
        readonly IUserRoleServices _userRoleServices;
        readonly IRoleServices _roleServices;
        readonly PermissionRequirement _requirement;
        private readonly IRoleModulePermissionServices _roleModulePermissionServices;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="sysUserInfoServices"></param>
        /// <param name="userRoleServices"></param>
        /// <param name="roleServices"></param>
        /// <param name="requirement"></param>
        /// <param name="roleModulePermissionServices"></param>
        public LoginController(ISysUserInfoServices sysUserInfoServices, IUserRoleServices userRoleServices, IRoleServices roleServices, PermissionRequirement requirement, IRoleModulePermissionServices roleModulePermissionServices)
        {
            this._sysUserInfoServices = sysUserInfoServices;
            this._userRoleServices = userRoleServices;
            this._roleServices = roleServices;
            _requirement = requirement;
            _roleModulePermissionServices = roleModulePermissionServices;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("token")]
        [Caching]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetJwtStr(string name, string password)
        {
            var user = await _sysUserInfoServices.GetUserRoleNameStr(name, MD5Helper.MD5Encrypt32(password));
            if (user != null)
            {
                TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = user };
                return Ok(JwtHelper.IssueJwt(tokenModel));
            }
            else
            {
                return BadRequest("login fail");
            }
        }
    }
}
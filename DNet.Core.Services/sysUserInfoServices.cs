	//----------sysUserInfo开始----------
    


using System;
using System.Threading.Tasks;
using DNet.Core.Common;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.IServices;
using DNet.Core.Model.Models;
using DNet.Core.Services.BASE;
namespace DNet.Core.Services
{	
	/// <summary>
	/// sysUserInfoServices
	/// </summary>	
	public class sysUserInfoServices : BaseServices<sysUserInfo>, IsysUserInfoServices
    {
	
        IsysUserInfoRepository dal;
        public sysUserInfoServices(IsysUserInfoRepository dal)
        {
            this.dal = dal;
            base.BaseDal = dal;
        }
       
    }
}

	//----------sysUserInfo结束----------
	
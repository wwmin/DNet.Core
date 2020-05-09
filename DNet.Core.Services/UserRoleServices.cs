	//----------UserRole开始----------
    


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
	/// UserRoleServices
	/// </summary>	
	public class UserRoleServices : BaseServices<UserRole>, IUserRoleServices
    {
	
        IUserRoleRepository dal;
        public UserRoleServices(IUserRoleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------UserRole结束----------
	
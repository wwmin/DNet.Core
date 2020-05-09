	//----------sysUserInfo开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// sysUserInfoRepository
	/// </summary>	
	public class sysUserInfoRepository : BaseRepository<sysUserInfo>, IsysUserInfoRepository
    {
		public sysUserInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------sysUserInfo结束----------
	
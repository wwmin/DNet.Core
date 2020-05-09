	//----------UserRole开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// UserRoleRepository
	/// </summary>	
	public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
		public UserRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------UserRole结束----------
	
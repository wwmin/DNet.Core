	//----------Permission开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// PermissionRepository
	/// </summary>	
	public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
		public PermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------Permission结束----------
	
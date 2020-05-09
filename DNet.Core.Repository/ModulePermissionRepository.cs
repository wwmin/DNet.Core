	//----------ModulePermission开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// ModulePermissionRepository
	/// </summary>	
	public class ModulePermissionRepository : BaseRepository<ModulePermission>, IModulePermissionRepository
    {
		public ModulePermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------ModulePermission结束----------
	
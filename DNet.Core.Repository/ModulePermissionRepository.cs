using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.Model.Models;
using DNet.Core.Repository.Base;

namespace DNet.Core.Repository
{
    public class ModulePermissionRepository : BaseRepository<ModulePermission>, IModulePermissionRepository
    {
        public ModulePermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

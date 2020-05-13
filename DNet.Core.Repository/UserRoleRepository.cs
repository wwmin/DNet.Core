using DNet.Core.FrameWork.IRepository;
using DNet.Core.Repository.Base;
using DNet.Core.Model.Models;
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

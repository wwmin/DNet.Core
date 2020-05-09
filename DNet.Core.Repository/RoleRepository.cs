	//----------Role开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// RoleRepository
	/// </summary>	
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
		public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------Role结束----------
	
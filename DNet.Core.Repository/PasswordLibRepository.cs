	//----------PasswordLib开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// PasswordLibRepository
	/// </summary>	
	public class PasswordLibRepository : BaseRepository<PasswordLib>, IPasswordLibRepository
    {
		public PasswordLibRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------PasswordLib结束----------
	
	//----------Advertisement开始----------
    
using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// AdvertisementRepository
	/// </summary>	
	public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
		public AdvertisementRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------Advertisement结束----------
	
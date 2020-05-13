using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.Model.Models;
using DNet.Core.Repository.Base;

namespace DNet.Core.Repository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

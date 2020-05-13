using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.Model.Models;
using DNet.Core.Repository.Base;

namespace DNet.Core.Repository
{
    public class GuestbookRepository : BaseRepository<Guestbook>, IGuestbookRepository
    {
        public GuestbookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }



    }
}

	//----------Guestbook开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// GuestbookRepository
	/// </summary>	
	public class GuestbookRepository : BaseRepository<Guestbook>, IGuestbookRepository
    {
		public GuestbookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------Guestbook结束----------
	
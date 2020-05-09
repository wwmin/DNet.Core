	//----------Guestbook开始----------
    


using System;
using System.Threading.Tasks;
using DNet.Core.Common;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.IServices;
using DNet.Core.Model.Models;
using DNet.Core.Services.BASE;
namespace DNet.Core.Services
{	
	/// <summary>
	/// GuestbookServices
	/// </summary>	
	public class GuestbookServices : BaseServices<Guestbook>, IGuestbookServices
    {
	
        IGuestbookRepository dal;
        public GuestbookServices(IGuestbookRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Guestbook结束----------
	
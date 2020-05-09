	//----------Topic开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// TopicRepository
	/// </summary>	
	public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
		public TopicRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------Topic结束----------
	
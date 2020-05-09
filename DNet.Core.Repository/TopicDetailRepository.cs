	//----------TopicDetail开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// TopicDetailRepository
	/// </summary>	
	public class TopicDetailRepository : BaseRepository<TopicDetail>, ITopicDetailRepository
    {
		public TopicDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------TopicDetail结束----------
	
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.Model.Models;
using DNet.Core.Repository.Base;

namespace DNet.Core.Repository
{
    public class TopicDetailRepository : BaseRepository<TopicDetail>, ITopicDetailRepository
    {
        public TopicDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

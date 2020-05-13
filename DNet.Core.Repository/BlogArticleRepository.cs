using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.Model.Models;
using DNet.Core.Repository.Base;

namespace DNet.Core.Repository
{
    public class BlogArticleRepository : BaseRepository<BlogArticle>, IBlogArticleRepository
    {
        public BlogArticleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

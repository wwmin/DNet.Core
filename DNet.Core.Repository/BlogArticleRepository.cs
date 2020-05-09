	//----------BlogArticle开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// BlogArticleRepository
	/// </summary>	
	public class BlogArticleRepository : BaseRepository<BlogArticle>, IBlogArticleRepository
    {
		public BlogArticleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------BlogArticle结束----------
	
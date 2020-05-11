	//----------BlogArticle开始----------
    

using DNet.Core.IServices.BASE;
using DNet.Core.Model.Models;
using DNet.Core.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNet.Core.IServices
{	
	/// <summary>
	/// BlogArticleServices
	/// </summary>	
    public interface IBlogArticleServices :IBaseServices<BlogArticle>
	{
		Task<List<BlogArticle>> GetBlogs();
		Task<BlogViewModels> GetBlogDetails(int id);

	}
}

	//----------BlogArticle结束----------
	
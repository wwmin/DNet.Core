	//----------BlogArticle开始----------
    


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
	/// BlogArticleServices
	/// </summary>	
	public class BlogArticleServices : BaseServices<BlogArticle>, IBlogArticleServices
    {
	
        IBlogArticleRepository dal;
        public BlogArticleServices(IBlogArticleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------BlogArticle结束----------
	
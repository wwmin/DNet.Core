using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DNet.Core.Common;
using DNet.Core.IServices;
using DNet.Core.Model;
using DNet.Core.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;

namespace DNet.Core.Controllers
{
    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        readonly IBlogArticleServices _blogArticleServices;
        private readonly ILogger<BlogController> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="blogArticleServices"></param>
        /// <param name="logger"></param>
        public BlogController(IBlogArticleServices blogArticleServices, ILogger<BlogController> logger)
        {
            _blogArticleServices = blogArticleServices;
            _logger = logger;
        }

        /// <summary>
        /// 获取博客列表【无权限】
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="bcategory"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [ResponseCache(Duration = 600)]
        public async Task<MessageModel<PageModel<BlogArticle>>> Get(int id, int page = 1, string bcategory = "技术博文", string key = "")
        {
            int intPageSize = 6;
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
            {
                key = "";
            }

            Expression<Func<BlogArticle, bool>> whereExpression = a => (a.bcategory == bcategory && a.IsDeleted == false) && ((a.btitle != null && a.btitle.Contains(key)) || (a.bcontent != null && a.bcontent.Contains(key)));

            var pageModelBlog = await _blogArticleServices.QueryPage(whereExpression, page, intPageSize, " bID desc ");

            using (MiniProfiler.Current.Step("获取成功后，开始处理最终数据"))
            {
                foreach (var item in pageModelBlog.data)
                {
                    if (!string.IsNullOrEmpty(item.bcontent))
                    {
                        item.bRemark = (HtmlHelper.ReplaceHtmlTag(item.bcontent)).Length >= 200 ? (HtmlHelper.ReplaceHtmlTag(item.bcontent)).Substring(0, 200) : (HtmlHelper.ReplaceHtmlTag(item.bcontent));
                        int totalLength = 500;
                        if (item.bcontent.Length > totalLength)
                        {
                            item.bcontent = item.bcontent.Substring(0, totalLength);
                        }
                    }
                }
            }

            return new MessageModel<PageModel<BlogArticle>>()
            {
                success = true,
                msg = "获取成功",
                response = new PageModel<BlogArticle>()
                {
                    page = page,
                    dataCount = pageModelBlog.dataCount,
                    data = pageModelBlog.data,
                    pageCount = pageModelBlog.pageCount,
                }
            };
        }

    }
}
using DNet.Core.IServices.WebApiClients.HttpApis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient.Extensions.DependencyInjection;

namespace DNet.Core.Extensions
{
    /// <summary>
    /// WebApiClientSetup 启动服务
    /// </summary>
    public static class WebApiClientSetup
    {
        /// <summary>
        /// 注册WebApiClient接口
        /// </summary>
        /// <param name="services"></param>
        public static void AddHttpApiSetup(this IServiceCollection services)
        {
            services.AddHttpApi<IBlogApi>().ConfigureHttpApiConfig(c =>
            {
                //c.HttpHost = new Uri("http://localhost:5000/");
                c.FormatOptions.DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            });
        }
    }
}

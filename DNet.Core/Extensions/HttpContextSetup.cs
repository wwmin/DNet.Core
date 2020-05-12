using DNet.Core.Common.HttpContextUser;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNet.Core.Extensions
{
    /// <summary>
    /// HttpContext
    /// </summary>
    public static class HttpContextSetup
    {
        /// <summary>
        /// HttpContext服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddHttpContextSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}

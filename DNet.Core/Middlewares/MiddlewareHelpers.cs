﻿using DNet.Core.AuthHelper;
using Microsoft.AspNetCore.Builder;

namespace DNet.Core.Middlewares
{
    public static class MiddlewareHelpers
    {
        /// <summary>
        /// 自定义授权中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJwtTokenAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JwtTokenAuth>();
        }

        /// <summary>
        /// 请求响应中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseReuestResponseLogMidd(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequRespLogMidd>();
        }

        /// <summary>
        /// SignalR中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSignalRSendMidd(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SignalRSendMidd>();
        }

        /// <summary>
        /// 异常处理中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseExceptionHandlerMidd(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMidd>();
        }

        /// <summary>
        /// IP请求中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseIPLogMidd(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IPLogMidd>();
        }
    }
}

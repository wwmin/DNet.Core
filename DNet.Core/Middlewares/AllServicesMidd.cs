﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNet.Core.Middlewares
{
    /// <summary>
    /// 查看所有已注册的服务
    /// </summary>
    public static class AllServicesMidd
    {
        public static void UseAllServicesMidd(this IApplicationBuilder app, IServiceCollection _services, List<Type> tsDIAutofac)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.Map("/allservices", builder => builder.Run(async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("<style>.table2_1 table {width:100%;margin:15px 0}.table2_1 th {background-color:#93DAFF;color:#000000}.table2_1,.table2_1 th,.table2_1 td{font-size:0.95em;text-align:left;padding:4px;border:1px solid #c1e9fe;border-collapse:collapse}.table2_1 tr:nth-child(odd){background-color:#dbf2fe;}.table2_1 tr:nth-child(even){background-color:#fdfdfd;}</style>");

                await context.Response.WriteAsync($"<h3>所有服务{_services.Count}个</h3><table class='table2_1'><thead><tr><th>类型</th><th>生命周期</th><th>Instance</th></tr></thead><tbody>");

                foreach (var svc in _services)
                {
                    await context.Response.WriteAsync("<tr>");
                    await context.Response.WriteAsync($"<td>{svc.ServiceType.FullName}</td>");
                    await context.Response.WriteAsync($"<td>{svc.Lifetime}</td>");
                    await context.Response.WriteAsync($"<td>{svc.ImplementationType?.Name}</td>");
                    await context.Response.WriteAsync("</tr>");
                }
                foreach (var item in tsDIAutofac.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    foreach (var typeArray in interfaceType)
                    {
                        await context.Response.WriteAsync("<tr>");
                        await context.Response.WriteAsync($"<td>{typeArray?.FullName}</td>");
                        await context.Response.WriteAsync($"<td>Scoped</td>");
                        await context.Response.WriteAsync($"<td>{item?.Name}</td>");
                        await context.Response.WriteAsync("</tr>");
                    }
                }
                await context.Response.WriteAsync("</tbody></table>");
            }));
        }
    }
}

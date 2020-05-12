﻿using DNet.Core.Common;
using DNet.Core.Filter;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static DNet.Core.SwaggerHelper.CustomApiVersion;

namespace DNet.Core.Extensions
{
    /// <summary>
    /// Swagger启动服务
    /// </summary>
    public static class SwaggerSetup
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionFilter));
        /// <summary>
        /// 添加Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var basePath = AppContext.BaseDirectory;
            //var basePath2 = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            var ApiName = Appsettings.app(new string[] { "Startup", "ApiName" });

            services.AddSwaggerGen(c =>
            {
                //遍历出全部的版本,做文档信息展示
                typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo
                    {
                        Version = version,
                        Title = $"{ApiName} 接口文档--NetCore 3.1",
                        Description = $"{ApiName} Http Api " + version,
                        Contact = new OpenApiContact
                        {
                            Name = ApiName,
                            Email = "wwei.min@163.com"
                        },
                        License = new OpenApiLicense { Name = ApiName }
                    });
                    c.OrderActionsBy(o => o.RelativePath);
                });
                try
                {
                    var xmlPath = Path.Combine(basePath, "DNet.Core.xml");//这个就是从应用程序属性中配置的xml文件名
                    c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false,这个是controller的注释,记得修改

                    var xmlModelPath = Path.Combine(basePath, "DNet.Core.Model.xml");//这个就是Model层的xml文件名
                    c.IncludeXmlComments(xmlModelPath);
                }
                catch (Exception ex)
                {
                    log.Error("DNet.Core.xml和Blog.Core.Model.xml 丢失,请检查并拷贝.\n" + ex.Message);
                }

                //开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //在header中添加token,传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                //ids4和jwt切换
                if (Permissions.IsUseIds4)
                {
                    //接入IdentityServer4
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Implicit = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"{Appsettings.app(new string[] { "Startup", "IdentityServer4", "AuthorizationUrl" })}/connect/authorize"),
                                Scopes = new Dictionary<string, string> {
                                {
                                    "blog.core.api","ApiResource id"
                                }}
                            }
                        }
                    });
                }
                else
                {
                    // Jwt Bearer 认证,必须是 oauth2
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                        Name = "Authorization",//jwt默认的参数名称
                        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                        Type = SecuritySchemeType.ApiKey
                    });
                }
            });
        }
    }
}

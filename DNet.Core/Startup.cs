using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using DNet.Core.AOP;
using DNet.Core.Common;
using DNet.Core.Common.Redis;
using DNet.Core.Extensions;
using DNet.Core.Filter;
using DNet.Core.IServices;
using DNet.Core.Middlewares;
using DNet.Core.Model;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApiClient.Extensions.DependencyInjection;
using static DNet.Core.SwaggerHelper.CustomApiVersion;

namespace DNet.Core
{
    public class Startup
    {
        /// <summary>
        /// log4net�ִ���
        /// </summary>
        public static ILoggerRepository Repository { get; set; }
        private IServiceCollection _services;
        private List<Type> tsDIAutofac = new List<Type>();
        private static readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionFilter));
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();
            services.AddSingleton(new Appsettings(Configuration));
            services.AddSingleton(new LogLock(Env.ContentRootPath));

            Permissions.IsUseIds4 = Appsettings.app(new string[] { "Startup", "IdentityServer4", "Enabled" }).ObjToBool();

            services.AddMemoryCacheSetup();
            services.AddSqlsugarSetup();
            services.AddDbSetup();
            services.AddAutoMapperSetup();
            services.AddCorsSetup();
            services.AddMiniProfilerSetup();
            services.AddSwaggerSetup();
            services.AddJobSetup();
            services.AddHttpContextSetup();
            services.AddAppConfigSetup();
            services.AddHttpApiSetup();
            if (Permissions.IsUseIds4)
            {
                services.AddAuthorization_Ids4Setup();
            }
            else
            {
                services.AddAuthorizationSetup();
            }
            services.AddIpPolicyRateLimitSetup(Configuration);

            services.AddSignalR().AddNewtonsoftJsonProtocol();

            //services.AddScoped<UseServiceDIAttribute>();

            services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
                   .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);

            services.AddControllerSetup();
            _services = services;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();
            #region ���нӿڲ�ķ���ע��


            var servicesDllFile = Path.Combine(basePath, "DNet.Core.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "DNet.Core.Repository.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repository.dll��service.dll ��ʧ����Ϊ��Ŀ�����ˣ�������Ҫ��F6���룬��F5���У����� bin �ļ��У���������";
                log.Error(msg);
                throw new Exception(msg);
            }



            // AOP ���أ������Ҫ��ָ���Ĺ��ܣ�ֻ��Ҫ�� appsettigns.json ��Ӧ��Ӧ true ���С�
            var cacheType = new List<Type>();
            if (Appsettings.app(new string[] { "AppSettings", "RedisCachingAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<BlogRedisCacheAOP>();
                cacheType.Add(typeof(BlogRedisCacheAOP));
            }
            if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<BlogCacheAOP>();
                cacheType.Add(typeof(BlogCacheAOP));
            }
            if (Appsettings.app(new string[] { "AppSettings", "TranAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<BlogTranAOP>();
                cacheType.Add(typeof(BlogTranAOP));
            }
            if (Appsettings.app(new string[] { "AppSettings", "LogAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<BlogLogAOP>();
                cacheType.Add(typeof(BlogLogAOP));
            }

            // ��ȡ Service.dll ���򼯷��񣬲�ע��
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency()
                      .EnableInterfaceInterceptors()//����Autofac.Extras.DynamicProxy;
                      .InterceptedBy(cacheType.ToArray());//����������������б�����ע�ᡣ

            // ��ȡ Repository.dll ���򼯷��񣬲�ע��
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .InstancePerDependency();

            #endregion

            #region û�нӿڲ�ķ����ע��

            //��Ϊû�нӿڲ㣬���Բ���ʵ�ֽ��ֻ���� Load ������
            //ע�����ʹ��û�нӿڵķ��񣬲������ʹ�� AOP ���أ��ͱ�������Ϊ�鷽��
            //var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
            //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

            #endregion

            #region û�нӿڵĵ����࣬����class��������

            //ֻ��ע������е��鷽�����ұ�����public
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Love)))
                .EnableClassInterceptors()
                .InterceptedBy(cacheType.ToArray());
            #endregion

            #region ����ע��һ�����нӿڵ��࣬����interface��������

            //�����鷽��
            //builder.RegisterType<AopService>().As<IAopService>()
            //   .AsImplementedInterfaces()
            //   .EnableInterfaceInterceptors()
            //   .InterceptedBy(typeof(BlogCacheAOP));
            #endregion


            // �����ע��û��ϵ��ֻ�ǻ�ȡע���б������
            tsDIAutofac.AddRange(assemblysServices.GetTypes().ToList());
            tsDIAutofac.AddRange(assemblysRepository.GetTypes().ToList());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBlogArticleServices _blogArticleServices, ILoggerFactory loggerFactory)
        {
            //Ip����,�����Źܵ����
            app.UseIpRateLimiting();
            //��¼���еķ��ʼ�¼
            loggerFactory.AddLog4Net();
            //��¼�����뷵������
            app.UseRequestResponseLogMidd();
            // signalr
            app.UseSignalRSendMidd();
            // ��¼ip����
            app.UseIPLogMidd();
            //�鿴ע������з���
            app.UseAllServicesMidd(_services, tsDIAutofac);
            #region Environment
            if (env.IsDevelopment())
            {
                // �ڿ��������У�ʹ���쳣ҳ�棬�������Ա�¶�����ջ��Ϣ�����Բ�Ҫ��������������
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // �ڷǿ��������У�ʹ��HTTP�ϸ�ȫ����(or HSTS) ���ڱ���web��ȫ�Ƿǳ���Ҫ�ġ�
                // ǿ��ʵʩ HTTPS �� ASP.NET Core����� app.UseHttpsRedirection
                //app.UseHsts();
            }
            #endregion

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //���ݰ汾���Ƶ��� ����չʾ
                var ApiName = Appsettings.app(new string[] { "Startup", "ApiName" });
                typeof(ApiVersion).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ApiName} {version}");
                });

                // ��swagger��ҳ�����ó������Զ����ҳ�棬�ǵ�����ַ�����д�������������.index.html
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("DNet.Core.index.html");

                if (GetType().GetTypeInfo().Assembly.GetManifestResourceStream("DNet.Core.index.html") == null)
                {
                    var msg = "index.html�����ԣ���������ΪǶ�����Դ";
                    log.Error(msg);
                    throw new Exception(msg);
                }

                // ·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });
            #endregion

            // ������������ ע���±���Щ�м����˳�򣬺���Ҫ ������������
            app.UseCors("LimitRequests");
            // ��תhttps
            //app.UseHttpsRedirection();
            //ʹ�þ�̬�ļ�
            app.UseStaticFiles();
            //ʹ��cookie
            app.UseCookiePolicy();
            //���ش����� ,����404
            app.UseStatusCodePages();
            //Routing
            app.UseRouting();
            //�����Զ�����Ȩ�м��,���Գ���,�����Ƽ�
            //app.UseJwtTokenAuthMidd();
            // �ȿ�����֤
            app.UseAuthorization();
            // Ȼ������Ȩ�м��
            app.UseAuthorization();

            //�����쳣�м��,Ҫ�ŵ����
            //app.UseExceptionHandlerMidd();

            //�������
            app.UseMiniProfiler();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/api2/chatHub");
            });
        }
    }
}

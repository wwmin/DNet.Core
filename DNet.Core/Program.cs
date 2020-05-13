using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Autofac.Extensions.DependencyInjection;
using DNet.Core.Model;
using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DNet.Core
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("Log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            //生成承载web应用程序的Microsoft.AspNetCore.Hosting.IWebHost,Build是WebHostBuilder最终的目的,将返回一个构造的WebHost,最终生成宿主

            var host = CreateHostBuilder(args).Build();//.Run();
            var hadSeeded = Environment.GetEnvironmentVariable("ASPNETCORE_HAD_SEED");
            ConsoleHelper.WriteSuccessLine("数据库是否已经添加种子:" + (hadSeeded == "1" ? "是" : "否"));
            if (hadSeeded != "1")
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                    try
                    {
                        //从system.IServices提供程序获取T类型的服务
                        //数据库连接字符串是在Model层的Seed文件夹下的MyContext.cs中
                        var configuration = services.GetRequiredService<IConfiguration>();
                        if (configuration.GetSection("AppSettings")["SeedDBEnabled"].ObjToBool() || configuration.GetSection("AppSettings")["SeedDBDataEnabled"].ObjToBool())
                        {
                            var myContext = services.GetRequiredService<MyContext>();
                            var env = services.GetRequiredService<IWebHostEnvironment>();
                            DBSeed.SeedAsync(myContext, env.WebRootPath).Wait();
                            Environment.SetEnvironmentVariable("ASPNETCORE_HAD_SEED", "1");
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error($"Error occured seeding the Database.\n{e.Message}");
                        throw;
                    }
                }
            }

            // 运行 web 应用程序并阻止调用线程, 直到主机关闭。
            // 创建完 WebHost 之后，便调用它的 Run 方法，而 Run 方法会去调用 WebHost 的 StartAsync 方法
            // 将Initialize方法创建的Application管道传入以供处理消息
            // 执行HostedServiceExecutor.StartAsync方法
            // ※※※※ 有异常，查看 Log 文件夹下的异常日志 ※※※※  
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureLogging((hostingContext, builder) =>
                    {
                        builder.ClearProviders();
                        builder.SetMinimumLevel(LogLevel.Trace);
                        builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        builder.AddConsole();
                        builder.AddDebug();
                    });
                });
    }
}

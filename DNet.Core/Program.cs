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
            //���ɳ���webӦ�ó����Microsoft.AspNetCore.Hosting.IWebHost,Build��WebHostBuilder���յ�Ŀ��,������һ�������WebHost,������������

            var host = CreateHostBuilder(args).Build();//.Run();
            var hadSeeded = Environment.GetEnvironmentVariable("ASPNETCORE_HAD_SEED");
            ConsoleHelper.WriteSuccessLine("���ݿ��Ƿ��Ѿ��������:" + (hadSeeded == "1" ? "��" : "��"));
            if (hadSeeded != "1")
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                    try
                    {
                        //��system.IServices�ṩ�����ȡT���͵ķ���
                        //���ݿ������ַ�������Model���Seed�ļ����µ�MyContext.cs��
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

            // ���� web Ӧ�ó�����ֹ�����߳�, ֱ�������رա�
            // ������ WebHost ֮�󣬱�������� Run �������� Run ������ȥ���� WebHost �� StartAsync ����
            // ��Initialize����������Application�ܵ������Թ�������Ϣ
            // ִ��HostedServiceExecutor.StartAsync����
            // �������� ���쳣���鿴 Log �ļ����µ��쳣��־ ��������  
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

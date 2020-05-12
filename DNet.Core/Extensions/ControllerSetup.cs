using DNet.Core.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace DNet.Core.Extensions
{
    /// <summary>
    /// 启动controller服务
    /// </summary>
    public static class ControllerSetup
    {
        /// <summary>
        /// 注册controller
        /// </summary>
        /// <param name="services"></param>
        public static void AddControllerSetup(this IServiceCollection services)
        {
            services.AddControllers(o =>
            {
                //全局异常过滤
                o.Filters.Add(typeof(GlobalExceptionFilter));
                // 全局路由权限公约
                //o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
                // 全局路由前缀，统一修改路由
                o.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(RoutePrefix.Name)));
            }).AddNewtonsoftJson(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //options.UseCamelCasing(true);//使用驼峰样式key
                //设置时间格式
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            //如果不用newtonJson格式化日期可以启用下面的text.json格式化
            //.AddJsonOptions(options=>options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter()));
        }

    }


    /* 
    /// <summary>
    /// 日期格式转换器
    /// </summary>
    public class DateTimeJsonConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
    {
        /// <summary>
        /// read
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (string.IsNullOrWhiteSpace(reader.GetString()))
                    return DateTime.MinValue;

                if (DateTime.TryParse(reader.GetString(), out DateTime date))
                    return date;
            }
            return reader.GetDateTime();
        }

        /// <summary>
        /// write
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            if (value.Kind == DateTimeKind.Utc)
            {
                value = value.AddHours(8);//东八区时间
                writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
    }*/
}

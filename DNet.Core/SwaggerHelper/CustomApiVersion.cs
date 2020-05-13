using System.ComponentModel;

namespace DNet.Core.SwaggerHelper
{
    /// <summary>
    /// 自定义版本
    /// </summary>
    public class CustomApiVersion
    {
        /// <summary>
        /// Api接口版本 自定义
        /// </summary>
        public enum ApiVersions
        {
            /// <summary>
            /// V1 版本
            /// </summary>
            [Description("V1版本")]
            V1 = 1,
            /// <summary>
            /// V2 版本
            /// </summary>
            [Description("V2版本")]
            V2 = 2,
        }
    }
}

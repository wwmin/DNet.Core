using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DNet.Core.SwaggerHelper
{
    /// <summary>
    /// 自定义Api版本
    /// </summary>
    public class CustomApiVersion
    {
        public enum ApiVersion
        {
            /// <summary>
            /// V1版本
            /// </summary>
            [Description("V1版本")]
            V1 = 1,
            /// <summary>
            /// V2版本
            /// </summary>
            [Description("V2版本")]
            V2 = 2
        }
    }
}

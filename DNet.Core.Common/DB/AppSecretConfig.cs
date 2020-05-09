using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DNet.Core.Common
{
    public class AppSecretConfig
    {
        private static string Audience_Secret = Appsettings.app(new string[] { "Audience", "Secret" });
        private static string Audience_Secret_File = Appsettings.app(new string[] { "Audience", "SecretFile" });

        /// <summary>
        /// 优先使用本地文件
        /// </summary>
        public static string Audience_Secret_String => InitAudience_Secret();

        /// <summary>
        /// 优先使用本地文件
        /// </summary>
        /// <returns></returns>
        private static string InitAudience_Secret()
        {
            var securityString = DifDBConnOfSecurity(Audience_Secret_File);
            if (!string.IsNullOrEmpty(Audience_Secret_File) && !string.IsNullOrEmpty(securityString))
            {
                return securityString;
            }
            else
            {
                return Audience_Secret;
            }
        }

        private static string DifDBConnOfSecurity(params string[] conn)
        {
            foreach (var item in conn)
            {
                try
                {
                    if (File.Exists(item))
                    {
                        return File.ReadAllText(item).Trim();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("文件路径不存在");
                }
            }
            return conn[conn.Length - 1];
        }
    }
}

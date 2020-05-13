using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// �û���Ϣ��
    /// </summary>
    public class sysUserInfo
    {
        public sysUserInfo() { }

        public sysUserInfo(string loginName, string loginPWD)
        {
            uLoginName = loginName;
            uLoginPWD = loginPWD;
            uRealName = uLoginName;
            uStatus = 0;
            uCreateTime = DateTime.Now;
            uUpdateTime = DateTime.Now;
            uLastErrTime = DateTime.Now;
            uErrorCount = 0;
            name = "";

        }
        /// <summary>
        /// �û�ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int uID { get; set; }
        /// <summary>
        /// ��¼�˺�
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string uLoginName { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string uLoginPWD { get; set; }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string uRealName { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        public int uStatus { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string uRemark { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime uCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime uUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        ///����¼ʱ�� 
        /// </summary>
        public DateTime uLastErrTime { get; set; } = DateTime.Now;

        /// <summary>
        ///������� 
        /// </summary>
        public int uErrorCount { get; set; }



        /// <summary>
        /// ��¼�˺�
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string name { get; set; }

        // �Ա�
        [SugarColumn(IsNullable = true)]
        public int sex { get; set; } = 0;
        // ����
        [SugarColumn(IsNullable = true)]
        public int age { get; set; }
        // ����
        [SugarColumn(IsNullable = true)]
        public DateTime birth { get; set; } = DateTime.Now;
        // ��ַ
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string addr { get; set; }

        [SugarColumn(IsNullable = true)]
        public bool tdIsDelete { get; set; }


        [SugarColumn(IsIgnore = true)]
        public List<int> RIDs { get; set; }
        [SugarColumn(IsIgnore = true)]
        public List<string> RoleNames { get; set; }

    }
}	 

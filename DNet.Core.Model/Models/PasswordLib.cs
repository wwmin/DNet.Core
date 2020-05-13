using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// ������
    /// </summary>
    [SugarTable("PasswordLib")]
    public class PasswordLib
    {
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int PLID { get; set; }

        /// <summary>
        ///��ȡ�������Ƿ���ã��߼��ϵ�ɾ����������ɾ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }

        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string plURL { get; set; }

        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string plPWD { get; set; }

        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string plAccountName { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? plStatus { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? plErrorCount { get; set; }

        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string plHintPwd { get; set; }

        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string plHintquestion { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? plCreateTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? plUpdateTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? plLastErrTime { get; set; }

        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string test { get; set; }


    }
}	 

using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// ��־��¼
    /// </summary>
    public class OperateLog : RootEntity
    {

        /// <summary>
        ///��ȡ�������Ƿ���ã��߼��ϵ�ɾ����������ɾ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string Area { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string Controller { get; set; }
        /// <summary>
        /// Action����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string Action { get; set; }
        /// <summary>
        /// IP��ַ
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string IPAddress { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? LogTime { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string LoginName { get; set; }
        /// <summary>
        /// �û�ID
        /// </summary>
        public int UserId { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual sysUserInfo User { get; set; }
    }
}	 

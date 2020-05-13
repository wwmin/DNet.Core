using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    ///<summary>
    ///Guestbook
    ///</summary>
    public class Guestbook
    {

        /// <summary>
        /// ���Ա�
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        /// <summary>����ID
        /// 
        /// </summary>
        public int? blogId { get; set; }
        /// <summary>����ʱ��
        /// 
        /// </summary>
        public DateTime createdate { get; set; }

        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string username { get; set; }

        /// <summary>�ֻ�
        /// 
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string phone { get; set; }
        /// <summary>qq
        /// 
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string QQ { get; set; }

        /// <summary>��������
        /// 
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string body { get; set; }
        /// <summary>ip��ַ
        /// 
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string ip { get; set; }

        /// <summary>�Ƿ���ʾ��ǰ̨,0��1��
        /// 
        /// </summary>
        public bool isshow { get; set; }

        [SugarColumn(IsIgnore = true)]
        public BlogArticle blogarticle { get; set; }
    }
}	 

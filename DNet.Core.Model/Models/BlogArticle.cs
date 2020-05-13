using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// ��������
    /// </summary>
    public class BlogArticle
    {
        /// <summary>
        /// ����
        /// </summary>
        /// ����֮����û��RootEntity�����뱣�ֺ�֮ǰ�����ݿ�һ�£�������bID������Id
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int bID { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 60, IsNullable = true)]
        public string bsubmitter { get; set; }

        /// <summary>
        /// ����blog
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 256, IsNullable = true)]
        public string btitle { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string bcategory { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string bcontent { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int btraffic { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int bcommentNum { get; set; }

        /// <summary> 
        /// �޸�ʱ��
        /// </summary>
        public DateTime bUpdateTime { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime bCreateTime { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string bRemark { get; set; }

        /// <summary>
        /// �߼�ɾ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }

    }
}	 

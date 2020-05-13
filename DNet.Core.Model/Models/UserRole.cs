using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// �û�����ɫ������
    /// </summary>
    public class UserRole : RootEntity
    {
        public UserRole() { }

        public UserRole(int uid, int rid)
        {
            UserId = uid;
            RoleId = rid;
            CreateTime = DateTime.Now;
            IsDeleted = false;
            CreateId = uid;
            CreateTime = DateTime.Now;
        }



        /// <summary>
        ///��ȡ�������Ƿ���ã��߼��ϵ�ɾ����������ɾ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// �û�ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// ��ɫID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? CreateId { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string CreateBy { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// �޸�ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ModifyId { get; set; }
        /// <summary>
        /// �޸���
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string ModifyBy { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? ModifyTime { get; set; }

    }
}	 

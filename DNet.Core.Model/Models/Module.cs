using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// �ӿ�API��ַ��Ϣ��
    /// </summary>
    public class Module : RootEntity
    {
        public Module()
        {
            //this.ChildModule = new List<Module>();
            //this.ModulePermission = new List<ModulePermission>();
            //this.RoleModulePermission = new List<RoleModulePermission>();
        }


        /// <summary>
        ///��ȡ�������Ƿ���ã��߼��ϵ�ɾ����������ɾ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// ��ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ParentId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string Name { get; set; }
        /// <summary>
        /// �˵����ӵ�ַ
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string LinkUrl { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string Area { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string Controller { get; set; }
        /// <summary>
        /// Action����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = int.MaxValue, IsNullable = true)]
        public string Action { get; set; }
        /// <summary>
        /// ͼ��
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string Icon { get; set; }
        /// <summary>
        /// �˵����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 10, IsNullable = true)]
        public string Code { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public int OrderSort { get; set; }
        /// <summary>
        /// /����
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        /// �Ƿ����Ҳ�˵�
        /// </summary>
        public bool IsMenu { get; set; }
        /// <summary>
        /// �Ƿ񼤻�
        /// </summary>
        public bool Enabled { get; set; }
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
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// �޸�ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ModifyId { get; set; }
        /// <summary>
        /// �޸���
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string ModifyBy { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? ModifyTime { get; set; } = DateTime.Now;

        //public virtual Module ParentModule { get; set; }
        //public virtual ICollection<Module> ChildModule { get; set; }
        //public virtual ICollection<ModulePermission> ModulePermission { get; set; }
        //public virtual ICollection<RoleModulePermission> RoleModulePermission { get; set; }
    }
}	 

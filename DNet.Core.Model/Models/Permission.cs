using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// ·�ɲ˵���
    /// </summary>
    public class Permission : RootEntity
    {
        public Permission()
        {
            //this.ModulePermission = new List<ModulePermission>();
            //this.RoleModulePermission = new List<RoleModulePermission>();
        }

        /// <summary>
        /// �˵�ִ��Action��
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string Code { get; set; }
        /// <summary>
        /// �˵���ʾ�������û�ҳ���༭(��ť)��ɾ��(��ť)��
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string Name { get; set; }
        /// <summary>
        /// �Ƿ��ǰ�ť
        /// </summary>
        public bool IsButton { get; set; } = false;
        /// <summary>
        /// �Ƿ������ز˵�
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsHide { get; set; } = false;
        /// <summary>
        /// �Ƿ�keepAlive
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IskeepAlive { get; set; } = false;


        /// <summary>
        /// ��ť�¼�
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string Func { get; set; }



        /// <summary>
        /// ��һ���˵���0��ʾ��һ���޲˵���
        /// </summary>
        public int Pid { get; set; }


        /// <summary>
        /// �ӿ�api
        /// </summary>
        public int Mid { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int OrderSort { get; set; }
        /// <summary>
        /// �˵�ͼ��
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string Icon { get; set; }
        /// <summary>
        /// �˵�����    
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        /// ����״̬
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
        public DateTime? CreateTime { get; set; } = DateTime.Now;
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
        public DateTime? ModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        ///��ȡ�������Ƿ���ã��߼��ϵ�ɾ����������ɾ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }




        [SugarColumn(IsIgnore = true)]
        public List<int> PidArr { get; set; }
        [SugarColumn(IsIgnore = true)]
        public List<string> PnameArr { get; set; } = new List<string>();
        [SugarColumn(IsIgnore = true)]
        public List<string> PCodeArr { get; set; } = new List<string>();
        [SugarColumn(IsIgnore = true)]
        public string MName { get; set; }

        [SugarColumn(IsIgnore = true)]
        public bool hasChildren { get; set; } = true;

        //public virtual ICollection<ModulePermission> ModulePermission { get; set; }
        //public virtual ICollection<RoleModulePermission> RoleModulePermission { get; set; }
    }
}	 

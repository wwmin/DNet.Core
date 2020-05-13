using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
    /// <summary>
    /// ����ƻ���
    /// </summary>
    public class TasksQz : RootEntity
    {
        /// <summary>
        /// ��������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string Name { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string JobGroup { get; set; }
        /// <summary>
        /// ��������ʱ����ʽ
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string Cron { get; set; }
        /// <summary>
        /// ��������DLL��Ӧ�ĳ�������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string AssemblyName { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string ClassName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// ִ�д���
        /// </summary>
        public int RunTimes { get; set; }
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// ���������ͣ�0��simple 1��cron��
        /// </summary>
        public int TriggerType { get; set; }
        /// <summary>
        /// ִ�м��ʱ��, ��Ϊ��λ
        /// </summary>
        public int IntervalSecond { get; set; }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsStart { get; set; } = false;
        /// <summary>
        /// ִ�д���
        /// </summary>
        public string JobParams { get; set; }


        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}	 

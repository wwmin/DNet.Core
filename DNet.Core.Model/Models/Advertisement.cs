using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DNet.Core.Model.Models
{
	 ///<summary>
	 ///Advertisement
	 ///</summary>
	 [Table("Advertisement")]	
	 public class Advertisement
	 {
	 
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		public int Id { get; set; }
	
		/// <summary>
        /// 图片路径
        /// </summary>
		public string ImgUrl { get; set; }
	
		/// <summary>
        /// Title
        /// </summary>
		public string Title { get; set; }
	
		/// <summary>
        /// Url
        /// </summary>
		public string Url { get; set; }
	
		/// <summary>
        /// Remark
        /// </summary>
		public string Remark { get; set; }
	
		/// <summary>
        /// Createdate
        /// </summary>
		[Required]
		public DateTime Createdate { get; set; }
	 
	 }
}	 

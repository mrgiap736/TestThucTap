using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Entities
{
	public class Staff
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }

		[StringLength(15, ErrorMessage = "Mã chỉ được phép nhỏ hơn 15 ký tự")]
		public string Code { get; set; }

		[RegularExpression(@"^[a-z0-9._%+-]+@fe\.edu\.vn$", ErrorMessage = "Email phải kết thúc bằng đuôi @fe.edu.vn không chứa khoảng trắng và tiếng việt")]
		public string AccountFE { get; set; }

		[RegularExpression(@"^[a-z0-9._%+-]+@fpt\.edu\.vn$", ErrorMessage = "Email phải kết thúc bằng đuôi @fpt.edu.vn không chứa khoảng trắng và tiếng việt")]
		public string AccountFPT { get; set; }
		public int Status { get; set; }

		//
		public virtual ICollection<Staff_MajorFacility> Staff_Majors { get; set; }
	}
}

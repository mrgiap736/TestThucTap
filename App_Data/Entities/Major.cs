using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Entities
{
	public class Major
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }

		//
		public virtual ICollection<Major_Facility> Major_Facilities { get; set; }
	}

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Entities
{
	public class Department_Facility
	{
		[Key]
		public Guid Id { get; set; }
		public Guid DepartmentId { get; set; }
		public Guid FacilityId { get; set; }

		//
		public Department Department { get; set; }
		public Facility Facility { get; set; }
		public virtual ICollection<Major_Facility> Major_Facilities { get; set; }
	}
}

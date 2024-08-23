using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Entities
{
	public class Major_Facility
	{
		[Key]
		public Guid Id { get; set; }
		public Guid department_FacilityId { get; set; }
		public Guid MajorId { get; set; }

		public Department_Facility department_Facility { get; set; }
		public Major Major { get; set; }
		public virtual ICollection<Staff_MajorFacility> Staff_Majors { get; set; }
	}
}

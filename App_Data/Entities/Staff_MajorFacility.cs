using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Entities
{
	public class Staff_MajorFacility
	{
		[Key]
		public Guid Id { get; set; }
		public Guid major_FacilityId { get; set; }
		public Guid StaffId { get; set; }

		public Major_Facility major_Facility { get; set; }
		public Staff Staff { get; set; }
	}
}

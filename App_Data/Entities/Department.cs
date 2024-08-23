﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Entities
{
	public class Department
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }

		public virtual ICollection<Department_Facility> Department_Facilities { get; set; }
	}
}

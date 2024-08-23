using App_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configuration
{
	public class Staff_Config : IEntityTypeConfiguration<Staff>
	{
		public void Configure(EntityTypeBuilder<Staff> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.AccountFE).IsUnique();
			builder.HasIndex(x => x.AccountFPT).IsUnique();
			builder.HasIndex(x => x.Code).IsUnique();
		}
	}
}

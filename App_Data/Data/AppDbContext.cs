using App_Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext()
        {
                
        }

		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Department> Department { get; set; }
		public DbSet<Department_Facility> Department_Facility { get; set; }
		public DbSet<Facility> Facility { get; set; }
		public DbSet<Major> Major { get; set; }
		public DbSet<Major_Facility> Major_Facility { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<Staff_MajorFacility> Staff_Major { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=MRG;Initial Catalog=TestThucTap;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}


using App_Data.AutoMapperProfile;
using App_Data.Data;
using App_Data.ImplementRepos;
using App_Data.InterfaceRepos;
using App_DTO.InterfaceRepos;

namespace App_Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddAutoMapper(typeof(StaffProfile).Assembly);
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<AppDbContext>();
			builder.Services.AddScoped<IStaffRepos, StaffRepos>();
			builder.Services.AddScoped<IStaff_MajorRepos, Staff_MajorRepos>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}

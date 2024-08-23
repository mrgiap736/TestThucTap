using App_Data.AutoMapperProfile;
using App_Data.Data;
using App_View.Services;

namespace App_View
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddAutoMapper(typeof(StaffProfile).Assembly);
			//add th?ng do h?t th?i gian :))
			builder.Services.AddDbContext<AppDbContext>();
			//
			builder.Services.AddTransient<HttpClient>();
			builder.Services.AddTransient<Staff_MajorServices>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=StaffMVC}/{action=Index}/{id?}");

			app.Run();
		}
	}
}

using Company.BLL.Repositories;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Company.ProjectMVC.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<DepartmentRepository>();
            builder.Services.AddScoped<EmployeRepository>();

            //builder.Services.AddScoped<UserManager<ApplicationUser>>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/SignIn";

			});


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
                pattern: "{controller=Account}/{action=SignIn}/{id?}");

		//pattern: "{controller=Home}/{action=Index}/{id?}");


			app.Run();
        }
    }
}

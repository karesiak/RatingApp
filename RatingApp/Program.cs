using Microsoft.EntityFrameworkCore;
using RatingApp.Data;

namespace RatingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<RatingContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("RatingContext")));

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
                pattern: "{controller=Ratings}/{action=Create}/{id?}");

            app.Run();
        }
    }
}
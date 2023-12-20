using FlightReservationV3.Context;
using FlightReservationV3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationV3;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer("Data Source=EREN-DESKTOP\\SQLEXPRESS;Initial Catalog=FlightReservationV3Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        });
        builder.Services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<AppDbContext>();

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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (userManager.Users.Any())
            {
                userManager.CreateAsync(new()
                {
                    Email = "y225012058@ogr.sakarya.edu.tr",
                    UserName = "Ýhsan",
                    UserFirstName = "Eren",
                    UserLastName = "Delibaþ",
                    EmailConfirmed = true,
                }, "sau").Wait();
            }
        }


        app.Run();
    }
}
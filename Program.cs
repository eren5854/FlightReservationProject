using FlightReservationProject.Context;
using FlightReservationProject.Models;
using FlightReservationProject.Repositories;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

namespace FlightReservationProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<PlaneRepository>();
        builder.Services.AddScoped<RouteRepository>();
        builder.Services.AddScoped<TicketRepository>();

        #region Localization
        //Localization yapýsý
        builder.Services.AddSingleton<LanguageService>();
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        builder.Services.AddMvc()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options =>
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName ?? "");
                    return factory.Create(nameof(SharedResource), assemblyName.Name ?? "");
                });
        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("tr-TR")
            };

            options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
            options.SupportedCultures = supportCultures;
            options.SupportedUICultures = supportCultures;
            options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
        });
        #endregion

        #region Context
        //Sql Server connection.
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
        });
        #endregion

        #region Authentication
        //Authentication yapýsý. Yetkisiz bir durumda otomatik olarak login sayfasýna yönlendirilecek.
        builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", configuration =>
        {
            configuration.AccessDeniedPath = "/Account/Login";
            configuration.LogoutPath = "/Account/Login";
            configuration.ExpireTimeSpan = TimeSpan.FromHours(1);
            configuration.Cookie.Name = "UserLoginCookie";
        });
        #endregion

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        #region Localization Middleware
        //Localization miidleware
        app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
        #endregion

        app.UseRouting();

        app.UseAuthorization();

        #region Admin User Route
        //Veri tabanýnda y225012058@sakarya.edu.tr email adýnda kayýtlý bir admin yoksa program çalýþtýðýnda default olarak admin ekliyor.
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (!context.Set<User>().Any(p => p.Email == "y225012058@sakarya.edu.tr"))
            {
                User user = new()
                {
                    FirstName = "Ýhsan Eren",
                    LastName = "Delibaþ",
                    Email = "y225012058@sakarya.edu.tr",
                    Password = "sau"
                };
                context.Set<User>().Add(user);
               
                Role? role = context.Set<Role>().Where(p => p.Name == "Admin").FirstOrDefault();
                if(role is null)
                {
                    role = new()
                    {
                        Name = "Admin"
                    };
                    context.Set<Role>().Add(role);

                }

                context.Set<UserRole>().Add(new()
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });

                context.SaveChanges();
            }

<<<<<<< HEAD
            if (!context.Set<User>().Any(p=>p.Email == "eren@gmail.com"))
=======
            if (!context.Set<User>().Any(p=>p.Email == "emin@gmail.com"))
>>>>>>> e705530f0dccf54861920124d88747cf8269c751
            {
                User user1 = new()
                {
                    FirstName = "Ýhsan Eren",
                    LastName = "Delibaþ",
                    Email = "eren@gmail.com",
                    Password = "eren123"
                };
                context.Set<User>().Add(user1);
                context.SaveChanges();
            }

            if (!context.Set<Plane>().Any())
            {
                Plane plane = new()
                {
                    Name = "Airbus",
                    TailNumber = "A330-200",
                    TotalSeats = 268,
                    SeatConfiguration = "2-4-2"
                };
                context.Set<Plane>().Add(plane);

                Plane plane2 = new()
                {
                    Name = "Embraer",
                    TailNumber = "700",
                    TotalSeats = 88,
                    SeatConfiguration = "2-2"
                };
                context.Set<Plane>().Add(plane2);
                context.SaveChanges();
            }

<<<<<<< HEAD
            if (!context.Set<Route>().Any())
=======
            if (!context.Set<Route>().Any(p => p.Departure == "Ýstanbul" && p.Arrival == "Ankara" && p.DepartureTime == DateTime.Parse("2024-02-21 15:30:00") && p.ArrivalTime == DateTime.Parse("2024-02-21 16:30:00")))
>>>>>>> e705530f0dccf54861920124d88747cf8269c751
            {
                Plane? plane = context.Set<Plane>().Where(p => p.Name == "Airbus" && p.TailNumber == "A330-200").FirstOrDefault();
                Plane? plane2 = context.Set<Plane>().Where(p => p.Name == "Embraer" && p.TailNumber == "700").FirstOrDefault();

                Route route = new()
                {
                    Departure = "Ýstanbul",
                    Arrival = "Ankara",
                    DepartureTime = DateTime.Parse("2024-01-10 15:30:00"),
                    ArrivalTime = DateTime.Parse("2024-01-10 16:30:00"),
                    PlaneId = plane!.Id
                };
                context.Set<Route>().Add(route);

                Route route2 = new()
                {
                    Departure = "Ýstanbul",
                    Arrival = "Ankara",
                    DepartureTime = DateTime.Parse("2024-01-10 12:30:00"),
                    ArrivalTime = DateTime.Parse("2024-01-10 13:30:00"),
                    PlaneId = plane2!.Id
                };
                context.Set<Route>().Add(route2);

                Route route3 = new()
                {
                    Departure = "Sivas",
                    Arrival = "Ýstanbul",
                    DepartureTime = DateTime.Parse("2024-01-11 09:30:00"),
                    ArrivalTime = DateTime.Parse("2024-01-11 11:00:00"),
                    PlaneId = plane2!.Id
                };
                context.Set<Route>().Add(route3);
                
                Route route4 = new()
                {
                    Departure = "Antalya",
                    Arrival = "Ankara",
                    DepartureTime = DateTime.Parse("2024-01-13 20:30:00"),
                    ArrivalTime = DateTime.Parse("2024-01-13 21:45:00"),
                    PlaneId = plane!.Id
                };
                context.Set<Route>().Add(route4);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update-Database
        //Programý her çalýþtýrdýðýmýzda otomatik olarak update-database iþlemini gerçekleþtiriyor.
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
        #endregion

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

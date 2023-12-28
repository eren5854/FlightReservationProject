using FlightReservationProject.Context;
using FlightReservationProject.Models;
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
            configuration.Cookie.Name = "UserLoinCookie";
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

        #region Admin Register
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

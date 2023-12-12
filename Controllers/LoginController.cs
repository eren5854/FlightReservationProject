using flightTicket.Context;
using flightTicket.DTOs;
using flightTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace flightTicket.Controllers;
public class LoginController : Controller
{
    private readonly AppDbContext _context = new AppDbContext();
    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Admin()
    {
        if(HttpContext.Session.GetString("SessionUser") is null)
        {
            TempData["hata"] = "Lütfen Giriş Yapınız";
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpPost]
    public IActionResult Login(AdminDto request, UserDto usrRequest)
    {
        Admin admin = _context.Admins.FirstOrDefault();
        User user = _context.Users.FirstOrDefault();
        if(admin.Email == request.Email && admin.Password == request.Password)
        {
            HttpContext.Session.SetString("SessionUser", admin.Name);
            var cokOpt = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(10)
            };
            HttpContext.Response.Cookies.Append("CookieName", request.Email, cokOpt);
            return RedirectToAction("Admin");
        }
        if(usrRequest.Email == user.Email)

        TempData["hata"] = "Kullanıcı Adı Veya Şifre Hatalı";
        return View("Index");
    }

    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}

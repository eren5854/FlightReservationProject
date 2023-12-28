using FlightReservationProject.Context;
using FlightReservationProject.DTOs;
using FlightReservationProject.Models;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlightReservationProject.Controllers;
public class AccountController : Controller
{
    private LanguageService _localization;
    private readonly ApplicationDbContext _context;

    public AccountController(LanguageService localization, ApplicationDbContext context)
    {
        _localization = localization;
        _context = context;
    }

    public IActionResult Login()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        ViewBag.Message = _localization.GetKey("LoginPage").Value;
        var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request)
    {
        User? user = _context.Set<User>().Where(p=>p.Email == request.Email && p.Password == request.Password).FirstOrDefault();
        if (user is null)
        {
            TempData["LoginError"] = "Kullanıcı Bulunamadı! Şifre veya Eposta hatalı!";
            return RedirectToAction("Login");
        }
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user!.FirstName + " " + user!.LastName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await HttpContext.SignInAsync(claimsPrincipal);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        User? user = _context.Set<User>().Where(p=>p.Email == request.Email).FirstOrDefault();
        if(user is not null)
        {
            TempData["KayıtHatası"] = "Bu email kullanılıyor";
            return RedirectToAction("Register", "Account");
        }

        user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
        };

        _context.Add(user);
        _context.SaveChanges();
        return RedirectToAction("RegisterSuccess");
    }

    public IActionResult RegisterSuccess()
    {
        return View();
    }

    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Login");
    }
}

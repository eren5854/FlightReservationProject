using FlightReservationProject.Context;
using FlightReservationProject.DTOs;
using FlightReservationProject.Models;
using FlightReservationProject.Repositories;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlightReservationProject.Controllers;
public class AccountController : Controller
{
    private LanguageService _localization;
    private readonly ApplicationDbContext _context;
    private readonly UserRepository _userRepository;

    public AccountController(LanguageService localization, ApplicationDbContext context, UserRepository userRepository)
    {
        _localization = localization;
        _context = context;
        _userRepository = userRepository;
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
        User? user = _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);
        if (user is null)
        {
            string message = _localization.GetKey("loginError");
            TempData["LoginError"] = message;
            TempData["Email"] = request.Email;
            TempData["Password"] = request.Password;
            return RedirectToAction("Login");
        }
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user!.FirstName + " " + user!.LastName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        List<string> roles = _userRepository.GetUserRoleByUserId(user.Id);

        await HttpContext.SignInAsync(claimsPrincipal);

        if (roles.Contains("Admin"))
        {
            return RedirectToAction("Index", "Admin");
        }

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
        User? user = _userRepository.GetUserByEmail(request.Email);
        if(user is not null)
        {
            string message = _localization.GetKey("RegisterError");
            TempData["KayıtHatası"] = message;
            return RedirectToAction("Register", "Account");
        }

        user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
        };

        _userRepository.Add(user);
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

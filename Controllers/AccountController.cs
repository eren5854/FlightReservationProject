using FlightReservationProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationProject.Controllers;
public class AccountController : Controller
{
    private LanguageService _localization;

    public AccountController(LanguageService localization)
    {
        _localization = localization;
    }

    public IActionResult Login()
    {
        ViewBag.Message = _localization.GetKey("LoginPage").Value;
        var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
}

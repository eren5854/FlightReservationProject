using FlightReservationProject.Models;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightReservationProject.Controllers;

[Authorize]
public class HomeController : Controller
{
    private LanguageService _localization;

    public HomeController(LanguageService localization)
    {
        _localization = localization;
    }
    public IActionResult Index()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        var user = User.Claims;
        return View();
    }
    
}

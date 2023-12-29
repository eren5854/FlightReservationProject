using FlightReservationProject.Repositories;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlightReservationProject.Controllers;

[Authorize]
public class AdminController : Controller
{
    private LanguageService _localization;
    private readonly UserRepository _userRepository;

    public AdminController(LanguageService localization, UserRepository userRepository)
    {
        _localization = localization;
        _userRepository = userRepository;
    }
    public IActionResult Index()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        string userId = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)!.Value;
        List<string> userRoles = _userRepository.GetUserRoleByUserId(Guid.Parse(userId));
        if (!userRoles.Contains("Admin"))
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
}

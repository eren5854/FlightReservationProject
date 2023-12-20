using Microsoft.AspNetCore.Mvc;

namespace FlightReservationV3.Controllers;
public class LoginRegisterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }
}

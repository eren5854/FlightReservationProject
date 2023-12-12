using Microsoft.AspNetCore.Mvc;

namespace flightTicket.Controllers;
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

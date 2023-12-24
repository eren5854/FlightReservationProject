using FlightReservationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightReservationProject.Controllers;

[Authorize]
public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    
}

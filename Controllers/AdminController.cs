using FlightReservationV3.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationV3.Controllers;
public class AdminController : Controller
{

    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    //[Authorize(Roles = "Admin")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateCity()
    {
        return View();
    }

    public IActionResult CreatePlane()
    {
        return View();
    }

    public IActionResult CreateSeat()
    {
        return View();
    }

    public IActionResult CreateFlight()
    {
        return View();
    }
    public IActionResult GetFlightList()
    {
        return View();
    }
    public IActionResult GetUserList()
    {
        return View();
    }
}

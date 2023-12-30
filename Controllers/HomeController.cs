using FlightReservationProject.DTOs;
using FlightReservationProject.Models;
using FlightReservationProject.Repositories;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FlightReservationProject.Controllers;

[Authorize]
public class HomeController : Controller
{
    private LanguageService _localization;
    private readonly UserRepository _userRepository;
    private readonly RouteRepository _routeRepository;
    private readonly TicketRepository _ticketRepository;

    public HomeController(LanguageService localization, UserRepository userRepository, RouteRepository routeRepository, TicketRepository ticketRepository)
    {
        _localization = localization;
        _userRepository = userRepository;
        _routeRepository = routeRepository;
        _ticketRepository = ticketRepository;
    }
    public IActionResult Index()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        string userId = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)!.Value;
        List<string> userRoles = _userRepository.GetUserRoleByUserId(Guid.Parse(userId));
        if (userRoles.Contains("Admin"))
        {
            return RedirectToAction("Index", "Admin");
        }

        //ViewBag.Date = DateTime.Now;
        return View(new List<Route>());
    }

    [HttpPost]
    public IActionResult Index(GetRouteDto request)
    {
        IEnumerable<Route> routes = _routeRepository.GetRoutesByParameter(request);
        TempData["Departure"] = request.Departure;
        TempData["Arrival"] = request.Arrival;
        return View(routes);
    }

    [HttpPost]
    public IActionResult AddTicket(AddTicketDto request)
    {
        string? userId = User.Claims.Where(p => p.Type == ClaimTypes.NameIdentifier).Select(s => s.Value).FirstOrDefault();

        if (userId is not null)
        {
            Ticket ticket = new()
            {
                RouteId = request.RouteId,
                SeatNumber = request.SeatNumber,
                UserId = Guid.Parse(userId),
            };
            if (ticket.Route?.DepartureTime <= DateTime.Now)
            {
                TempData["DateError"] = "gemniþ tarihli bilet alýnamaz";
                return RedirectToAction("Index");
            }
            _ticketRepository.Add(ticket);
        }

        return RedirectToAction("Index", "Ticket");
    }
}

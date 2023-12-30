using FlightReservationProject.DTOs;
using FlightReservationProject.Models;
using FlightReservationProject.Repositories;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationProject.Controllers;
public class RouteController : Controller
{
    private LanguageService _localization;
    private readonly RouteRepository _routeRepository;

    public RouteController(LanguageService localization, RouteRepository planeRepository)
    {
        _localization = localization;
        _routeRepository = planeRepository;
    }

    public IActionResult Index()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        IEnumerable<Route> routes = _routeRepository.GetAll();
        IEnumerable<Plane> planes = _routeRepository.GetAllPlane();
        RouteDto response = new()
        {
            Planes = planes,
            Routes = routes
        };
        return View(response);
    }

    [HttpPost]
    public IActionResult Add(AddRouteDto request)
    {
        Route route = new()
        {
            Arrival = request.Arrival,
            Departure = request.Departure,
            ArrivalTime = request.ArrivalTime,
            DepartureTime = request.DepartureTime,
            PlaneId = request.PlaneId
        };

        DateTime x = DateTime.Now;
        if (route.DepartureTime<=x)
        {
            TempData["DepartureTimeError"] = "Kalkış zamanı geçmiş tarihte olamaz!!";
            return RedirectToAction("Index");
        }

        _routeRepository.Add(route);
        return RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        _routeRepository.RemoveById(id);
        return RedirectToAction("Index");
    }
}

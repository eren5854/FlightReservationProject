using FlightReservationProject.DTOs;
using FlightReservationProject.Models;
using FlightReservationProject.Repositories;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationProject.Controllers;
public class PlanesController : Controller
{
    private LanguageService _localization;
    private readonly PlaneRepository _planeRepository;

    public PlanesController(LanguageService localization, PlaneRepository planeRepository)
    {
        _localization = localization;
        _planeRepository = planeRepository;
    }

    public IActionResult Index()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        var response = _planeRepository.GetAll();
        return View(response);
    }

    [HttpPost]
    public IActionResult Add(AddPlaneDto request)
    {
        bool isTailNumberExist = _planeRepository.CheckTailNumberExist(request.TailNumber);
        if (isTailNumberExist)
        {
            TempData["TailNumberError"] = "Bu kuyruk numaralı uçak zaten kayıtlı";
            return RedirectToAction("Index");
        }
        Plane plane = new()
        {
            Name = request.Name,
            SeatConfiguration = request.SeatConfiguration,
            TailNumber = request.TailNumber,
            TotalSeats = request.TotalSeats,
        };
        _planeRepository.Add(plane);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        _planeRepository.RemoveById(id);
        return RedirectToAction("Index");
    }
}

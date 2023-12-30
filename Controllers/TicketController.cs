using FlightReservationProject.Models;
using FlightReservationProject.Repositories;
using FlightReservationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlightReservationProject.Controllers;
[Authorize]
public class TicketController : Controller
{
    private LanguageService _localization;
    public readonly TicketRepository _ticketRepository;
    public TicketController(TicketRepository ticketRepository, LanguageService localization)
    {
        _ticketRepository = ticketRepository;
        _localization = localization;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.SelectedLanguage = _localization.GetCurrentLanguage(Request);
        string? userId = User.Claims.Where(p => p.Type == ClaimTypes.NameIdentifier).Select(s => s.Value).FirstOrDefault();
        HttpClient client = new HttpClient();
        var response = await client.GetFromJsonAsync<List<Ticket>>("https://localhost:7217/api/TicketApi/GetAll?userId=" + userId);
        return View(response);
    }
}

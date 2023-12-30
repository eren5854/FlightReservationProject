using FlightReservationProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationProject.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TicketApiController : ControllerBase
{
    private readonly TicketRepository _ticketRepository;
    public TicketApiController(TicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    [HttpGet]
    public IActionResult GetAll(Guid userId)
    {
        var response = _ticketRepository.GetAll(userId);
        return Ok(response);
    }
}

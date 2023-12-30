using FlightReservationProject.Context;
using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationProject.Repositories;

public sealed class TicketRepository
{
    private readonly ApplicationDbContext _context;
    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Ticket ticket)
    {
        _context.Add(ticket);
        _context.SaveChanges();
    }

    public List<Ticket> GetAll(Guid userId)
    {
        return _context.Set<Ticket>().Where(p => p.UserId == userId).Include(p => p.User).Include(p => p.Route).ThenInclude(p => p!.Plane).ToList();
    }
}

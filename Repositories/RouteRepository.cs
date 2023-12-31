using FlightReservationProject.Context;
using FlightReservationProject.DTOs;
using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationProject.Repositories;

public sealed class RouteRepository
{
    private readonly ApplicationDbContext _context;
    public RouteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Route> GetAll()
    {
        return _context.Set<Route>().Include(p => p.Plane).OrderByDescending(o => o.DepartureTime).ToList();
    }

    public IEnumerable<Route> GetRoutesByParameter(GetRouteDto request)
    {
        return _context.Set<Route>()
            .Where(p=> 
                p.Departure == request.Departure && 
                p.Arrival == request.Arrival && 
                p.DepartureTime.Date == request.Date.Date)
            .Include(p => p.Plane)
            .OrderBy(p=> p.DepartureTime)
            .ToList();
    }

    public IEnumerable<Plane> GetAllPlane() 
    {
        return _context.Set<Plane>().OrderBy(p => p.Name).ToList();
    }

    public void Add(Route route)
    {
        _context.Add(route);
        _context.SaveChanges();
    }

    public void RemoveById(Guid id)
    {
        Route? route = _context.Set<Route>().Find(id);
        if (route is not null)
        {
            _context.Remove(route);
            _context.SaveChanges();
        }
    }
}

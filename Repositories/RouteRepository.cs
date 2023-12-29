using FlightReservationProject.Context;
using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationProject.Repositories;

public sealed class RouteRepository(ApplicationDbContext context)
{
    public IEnumerable<Route> GetAll()
    {
        return context.Set<Route>().Include(p => p.Plane).OrderByDescending(o => o.DepartureTime).ToList();
    }

    public IEnumerable<Plane> GetAllPlane() 
    {
        return context.Set<Plane>().OrderBy(p => p.Name).ToList();
    }

    public void Add(Route route)
    {
        context.Add(route);
        context.SaveChanges();
    }

    public void RemoveById(Guid id)
    {
        Route? route = context.Set<Route>().Find(id);
        if (route is not null)
        {
            context.Remove(route);
            context.SaveChanges();
        }
    }
}

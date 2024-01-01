using FlightReservationProject.Context;
using FlightReservationProject.Models;

namespace FlightReservationProject.Repositories;

public sealed class PlaneRepository
{
    private readonly ApplicationDbContext _context;
    public PlaneRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Plane> GetAll()
    {
        return _context.Set<Plane>().OrderBy(p => p.Name).ToList();
    }

    public void Add(Plane plane)
    {
        _context.Set<Plane>().Add(plane);
        _context.SaveChanges();
    }

    public bool CheckTailNumberExist(string tailNumber)
    {
        return _context.Set<Plane>().Any(p => p.TailNumber == tailNumber);
    }

    public void RemoveById(Guid id)
    {
        Plane? plane = _context.Set<Plane>().Find(id);
        if (plane != null)
        {
            _context.Remove(plane);
            _context.SaveChanges();
        }
    }
}

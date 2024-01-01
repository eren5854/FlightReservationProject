using FlightReservationProject.Context;
using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationProject.Repositories;

public sealed class UserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public User? GetUserByEmail(string email)
    {
        return _context.Set<User>().Where(p=> p.Email == email).FirstOrDefault();
    }

    public User? GetUserByEmailAndPassword(string email, string password)
    {
        return _context.Set<User>().Where(p=>p.Email == email && p.Password == password).FirstOrDefault();
    }

    public void Add(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }

    public List<string> GetUserRoleByUserId(Guid userId)
    {
        return _context.Set<UserRole>().Where(p => p.UserId == userId).Include(p => p.Role).Select(s => s.Role!.Name).ToList();
    }
}

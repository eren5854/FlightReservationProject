namespace flightTicket.Models;

public sealed class Flight
{
    public Flight() 
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FromWhere { get; set; }
    public string ToWhere { get; set; }
    public DateOnly DepartureDate { get; set; }
    public DateOnly ReturnDate {  get; set; }
    public int GuestId { get; set; }
    public int PlaneId { get; set; }
}

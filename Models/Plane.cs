namespace flightTicket.Models;

public sealed class Plane
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PassengerCapacity { get; set; }
    public int EconomySeatCapacity { get; set; }
    public int EconomySeatId { get; set; }
    public int BusinessSeatCapacity { get; set; }
    public int BusinessSeatId { get;set; }
}

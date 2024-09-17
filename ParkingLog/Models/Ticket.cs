namespace ParkingLot.Models;

public class Ticket
{
    public required Vehicle VehicleAssigned { get; set; }
    public DateTime EntryTime { get; set; }
    public ParkingSpot? SpotAssigned { get; set; }
}

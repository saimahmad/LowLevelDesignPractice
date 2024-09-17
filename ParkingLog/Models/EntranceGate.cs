using ParkingLot.Models;

namespace ParkingLot.Models;

public class EntranceGate
{
    ParkingSpotManager ParkingSpotManager;

    public EntranceGate(ParkingSpotManager spotManager)
    {
        if(spotManager == null) throw new ArgumentNullException(nameof(spotManager));
        ParkingSpotManager = spotManager;
    }

    public Ticket GenerateTicket(Vehicle vehicle)
    {
        return new Ticket()
        {
            VehicleAssigned = vehicle,
            SpotAssigned = ParkingSpotManager.ParkVehicle(vehicle),
            EntryTime = DateTime.Now,
        };
    }
}

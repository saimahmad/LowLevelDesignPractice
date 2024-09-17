using ParkingLot.Models;

namespace ParkingLot.Models;

public class ExitGate
{
    ParkingSpotManager ParkingSpotManager;

    public ExitGate(ParkingSpotManager parkingSpotManager)
    {
        ParkingSpotManager = parkingSpotManager;
    }

    public int CalculateFee(Ticket ticket, DateTime exitTime)
    {
        return PriceManager.GetFinalPrice(ticket.VehicleAssigned.Type, ticket.EntryTime, exitTime);
    }

    public void RemoveVehicle(Ticket ticket) 
    {
        ////continue from here
        ParkingSpotManager.RemoveVehicle(ticket.VehicleAssigned);
    }
}

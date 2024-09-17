using ParkingLot.Models;

namespace ParkingLot.Models;

public class ParkingSpotManager
{
    List<ParkingSpot> ParkingSpots { get; set; } = [];

    public ParkingSpotManager(List<ParkingSpot> parkingSpots) 
    { 
        ParkingSpots = parkingSpots;
    }

    public ParkingSpot? ParkVehicle(Vehicle vehicle)
    {
        var parkingSpot = ParkingSpots.FirstOrDefault(p => p.IsEmpty());

        if (parkingSpot == null)
        {
            //return parkingSpot;
            throw new ArgumentException("No spot is available");
        }

        parkingSpot.ParkVehicle(vehicle); 
        return parkingSpot;
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        var parkingLot = ParkingSpots
            .FirstOrDefault(p => p.VehicleParked?.RegistrationNo == vehicle.RegistrationNo);

        if (parkingLot == null)
        {
            throw new ArgumentException("The vehicle is not parked in the parking lot.");
        }

        parkingLot.RemoveVehicle(vehicle);
    }
}

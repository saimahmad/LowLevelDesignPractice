using ParkingLot.Enums;

namespace ParkingLot.Models;

public abstract class ParkingSpot
{
    public ParkingSpot(string id)
    {
        Id = id;
        //pricePerHour = PricePerHour;
    }

    public string Id { get; set; }
    public Vehicle? VehicleParked { get; set; }
    //public int PricePerHour { get; set; }

    public bool IsEmpty() => VehicleParked == null;

    public void ParkVehicle(Vehicle vehicle)
    {
        if(VehicleParked != null)
        {
            throw new ArgumentException("Vehicle already parked");
        }

        VehicleParked = vehicle;
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        if(VehicleParked == null)
        {
            throw new ArgumentException("No vehicle is parked in the lot");
        }

        VehicleParked = null;
    }

    public abstract bool CanVehicleBeParked(VehicleType vehicleType);
}

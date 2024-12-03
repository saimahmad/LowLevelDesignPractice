using ParkingLot.Enums;

namespace ParkingLot.Models;

public class FourWheelerSpot : ParkingSpot
{
    public FourWheelerSpot(string id) : base(id)
    {
    }

    public override bool CanVehicleBeParked(VehicleType vehicleType)
    {
        return vehicleType == VehicleType.FourWheeler;
    }
}

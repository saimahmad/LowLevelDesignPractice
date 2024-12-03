using ParkingLot.Enums;

namespace ParkingLot.Models;

public class TwoWheelerSpot : ParkingSpot
{
    public TwoWheelerSpot(string id) : base(id)
    {
    }

    public override bool CanVehicleBeParked(VehicleType vehicleType)
    {
        return vehicleType == VehicleType.TwoWheeler;
    }
}

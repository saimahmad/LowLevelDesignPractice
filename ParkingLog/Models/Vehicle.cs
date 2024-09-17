using ParkingLot.Enums;

namespace ParkingLot.Models;

public class Vehicle
{
    public Vehicle(string registrationNo, VehicleType type)
    {
        RegistrationNo = registrationNo;
        Type = type;
    }

    public string RegistrationNo { get; set; }
    public VehicleType Type { get; set; }
}

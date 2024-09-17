using ParkingLot.Enums;

namespace ParkingLot.Models;

public static class PriceManager
{
    const int TwoWheelerPrice = 20;
    const int FourWheelerPrice = 45;

    public static int GetFinalPrice(VehicleType vehicleType, DateTime EntryTime, DateTime ExitTime)
    {
        var pricePerHour = GetPerHourPrice(vehicleType);

        var timeDifference = ExitTime.Subtract(EntryTime);
        var numberOfHours = timeDifference.Hours;
        var numberOfMinutes = timeDifference.Minutes;

        if (numberOfMinutes > 0) numberOfHours++;

        return numberOfHours * pricePerHour;
    }

    static int GetPerHourPrice(VehicleType vehicleType) 
    { 
        switch(vehicleType)
        {
            case VehicleType.TwoWheeler: return TwoWheelerPrice;
            case VehicleType.FourWheeler: return FourWheelerPrice;
            default: throw new ArgumentException("Invliad Vehicle Type");
        }
    }
}

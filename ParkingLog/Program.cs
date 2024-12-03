using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot;

internal class Program
{
    static void Main(string[] args)
    {
        //arrange

        List<ParkingSpot> parkingSpots = [];

        for(int i = 0; i < 1; i++)
        {
            parkingSpots.Add(new TwoWheelerSpot("tw" + i));
            parkingSpots.Add(new FourWheelerSpot("fw" + i));
        }

        var parkingSpotManager = new ParkingSpotManager(parkingSpots);
        var entranceGate = new EntranceGate(parkingSpotManager);
        var exitGate = new ExitGate(parkingSpotManager);

        try
        {
            //vehicles creation
            var v1 = new Vehicle("abc112", VehicleType.FourWheeler);
            var v2 = new Vehicle("xyz123", VehicleType.TwoWheeler);

            var t1 = entranceGate.GenerateTicket(v1);
            var t2 = entranceGate.GenerateTicket(v2);

            Console.WriteLine(exitGate.CalculateFee(t1, DateTime.Now.AddMinutes(20)));
            //exitGate.RemoveVehicle(t1);

            Console.WriteLine(exitGate.CalculateFee(t2, DateTime.Now.AddMinutes(70)));
            //exitGate.RemoveVehicle(t2);

            var v3 = new Vehicle("ttt111", VehicleType.FourWheeler);
            var t3 = entranceGate.GenerateTicket(v3);
            Console.WriteLine(t3.SpotAssigned);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

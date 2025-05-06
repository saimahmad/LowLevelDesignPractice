using CarRentalSystem.Models;
using System.Runtime.Intrinsics.X86;

namespace CarRentalSystem;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!, car rental");


        //in-memory databases
        var carManagers = PopulateCarManagerData();
        var users = PopulateUserData();
        IPricingStrategy pricintStrategyGeneral = new GeneralPricingStrategy();

        //testing
        var carRentalService = new CarRentalService(carManagers, users);

        carRentalService.GetAvailableCars(DateTime.Now, DateTime.Now.AddYears(2), new Location() { Latitude = 0, Longitude = 0 });
        Console.WriteLine();
        carRentalService.GetAvailableCars(DateTime.Now, DateTime.Now.AddYears(2), new Location() { Latitude = 19, Longitude = 19 });

        var booking1 = carRentalService.BookCar(DateTime.Now, DateTime.Now.AddDays(2), carManagers[0].Id, "ab123", pricintStrategyGeneral);

        PrintBookingDetails(booking1, carManagers);

    }

    static List<CarManager> PopulateCarManagerData()
    {
        return new List<CarManager>
         {
             new() {
                 Car = new Car
                 {
                     Id = 1,
                     Model = "TATA Altroz",
                     MakeYear = 2020
                 },
                 BasePerHourRate = 100,
                 CurrentLocation = new Location
                 {
                     Latitude = 0,
                     Longitude = 0,
                 }
             },
              new() {
                 Car = new Car
                 {
                     Id = 2,
                     Model = "Hunday i20",
                     MakeYear = 2018
                 },
                 BasePerHourRate = 150,
                 CurrentLocation = new Location
                 {
                     Latitude = 20,
                     Longitude = 20,
                 }
             }
         };
    }

    static List<User> PopulateUserData()
    {
        return new List<User>
        {
            new User()
            {
                Id = "ab123",
                Name = "Ajay",
                EmailId = "ajay@gmail.com"
            },
            new User()
            {
                Id = "cd123",
                Name = "Asif",
                EmailId = "asif@gmail.com"
            }
        };
    }

    static void PrintBookingDetails(UserBooking booking, List<CarManager> carManagers)
    {
        var carManager = carManagers.FirstOrDefault(_ => _.Id == booking.BookedCarManagerId);
        Console.WriteLine("");
        Console.WriteLine($"Booking done by user : {booking.UserId}, for the car: {carManager?.Car.Model}, total Amount to be paid : {booking.Bill.TotalAmount}");
    }
}

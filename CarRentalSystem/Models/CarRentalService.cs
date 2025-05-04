using CarRentalSystem.Enums;

namespace CarRentalSystem.Models;

public class CarRentalService
{
    List<CarManager> CarManagers;
    List<User> Users;
    List<UserBooking> Bookings;

    public CarRentalService(List<CarManager> carManagers, List<User> users)
    {
        CarManagers = carManagers;
        Users = users;
        Bookings = [];
    }

    public void GetAvailableCars(DateTime fromDate, DateTime toDate, Location? userLocation = null)
    {
        var availableCarManagers = CarManagers.Where(_ => _.IsAvailable(fromDate, toDate));
        if (userLocation != null)
        {
            availableCarManagers = CarManagers.OrderBy(_ => _.CurrentLocation?.CalculateDistance(userLocation)).ToList();
        }
        foreach(var carManager in availableCarManagers)
        {
            Console.WriteLine($"{carManager.Car.Model} ({carManager.Car.MakeYear})");
        }
    }

    public UserBooking BookCar(DateTime fromDate, DateTime toDate, Guid carManagerId, string userId, IPricingStrategy pricingStrategy)
    {
        var user = Users.FirstOrDefault(_ => _.Id == userId);

        if (user == null)
        {
            throw new ArgumentException("Invalid user.");
        }

        var carManager = CarManagers.FirstOrDefault(_ => _.Id == carManagerId);
        if (carManager == null)
        {
            throw new ArgumentException("Invalid car manager id");
        }

        if (!carManager.IsAvailable(fromDate, toDate))
        {
            throw new ArgumentException("Selected car not available in the given date range");
        }

        carManager.BookCar(fromDate, toDate);

        var bookingSlot = new BookingSlot()
        {
            StartDate = fromDate,
            EndDate = toDate
        };

        pricingStrategy = pricingStrategy ?? new GeneralPricingStrategy();

        var totalPrice = pricingStrategy.CalculatePrice(carManager.BasePerHourRate, bookingSlot);

        var bill = new Bill()
        {
            Status = BillStatus.Pending,
            TotalAmount = totalPrice
        };

        

        var booking =  new UserBooking()
        {
            UserId = userId,
            BookingSlot = bookingSlot,
            Bill = bill,
            BookedCarManagerId = carManagerId,
            BookingStatus = BookingStatus.Active
        };

        Bookings.Add(booking);

        return booking;

    }

    public void ProcessPayment(Guid userBookingId, PaymentMode paymentMode)
    {
        var userBooking = Bookings.FirstOrDefault(_ => _.Id == userBookingId);

        if (userBooking == null)
        {
            throw new ArgumentException("Invalid booking id");
        }

        var paymentProcessor = PaymentFactory.CreatePayment(paymentMode);

        paymentProcessor.ProcessPayment(userBooking.Bill.TotalAmount);

        userBooking.Bill.Status = BillStatus.Completed;
    }

    public void CancelBooking(Guid userBookingId)
    {

        var userBooking = Bookings.FirstOrDefault(_ => _.Id == userBookingId);

        if (userBooking == null)
        {
            throw new ArgumentException("Invalid booking id");
        }

        var carManager = CarManagers.FirstOrDefault(_ => _.Id == userBooking.BookedCarManagerId);

        carManager.EmptySlot(userBooking.BookingSlot.Id);
        Bookings.Remove(userBooking);
    }

    public void CompleteTrip(Guid userBookingId)
    {
        var userBooking = Bookings.FirstOrDefault(_ => _.Id == userBookingId);

        if (userBooking == null)
        {
            throw new ArgumentException("Invalid booking id");
        }

        userBooking.BookingStatus = BookingStatus.Completed;
    }

    public void GetBookings(string userId)
    {
        var bookings = Bookings.FindAll(_ => _.UserId == userId);

        foreach(var booking in bookings)
        {
            var carManager = CarManagers.FirstOrDefault(x => x.Id == booking.BookedCarManagerId);
            Console.WriteLine($"Car : {carManager?.Car.Model}, from {booking.BookingSlot?.StartDate} to {booking.BookingSlot?.EndDate}");
        }
    }

}

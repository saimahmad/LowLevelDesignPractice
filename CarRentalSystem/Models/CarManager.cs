namespace CarRentalSystem.Models;

public class CarManager
{
    public Guid Id = Guid.NewGuid();
    public required Car Car { get; set; }
    public Location? CurrentLocation { get; set; }
    public List<BookingSlot> BookingSchedule { get; set; } = [];
    public double BasePerHourRate { get; set; }

    public bool IsAvailable(DateTime fromDate, DateTime toDate)
    {
        return  !BookingSchedule.Any(booking => fromDate <= booking.EndDate && toDate >= booking.StartDate);
    }

    public void  BookCar(DateTime fromDate, DateTime toDate)
    {
        BookingSchedule.Add(new BookingSlot { StartDate = fromDate, EndDate = toDate });
    }

    public void EmptySlot(Guid slotId)
    {
        var bookingSlot = BookingSchedule.FirstOrDefault(booking => booking.Id == slotId);

        if (bookingSlot == null) 
        {
            throw new InvalidOperationException("Invalid booking slot id");
        }

        BookingSchedule.Remove(bookingSlot);
    }


}

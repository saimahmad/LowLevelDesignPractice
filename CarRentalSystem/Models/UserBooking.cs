using CarRentalSystem.Enums;

namespace CarRentalSystem.Models;

public class UserBooking
{
    public Guid Id = Guid.NewGuid();
    public Guid BookedCarManagerId { get; set; }
    public BookingSlot? BookingSlot { get; set; }
    public BookingStatus BookingStatus { get; set; }
    public Bill Bill { get; set; }
    public string UserId { get; set; }
}

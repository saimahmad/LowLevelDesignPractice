namespace CarRentalSystem.Models;

public class BookingSlot
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

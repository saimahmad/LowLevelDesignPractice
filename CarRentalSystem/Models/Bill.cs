using CarRentalSystem.Enums;

namespace CarRentalSystem.Models;

public class Bill
{
    public Guid Id { get; } = Guid.NewGuid();
    public double TotalAmount { get; set; }
    public BillStatus Status { get; set; }
}

namespace CarRentalSystem.Models;

public class Car
{
    public int Id { get; set; }
    public required string Model { get; set; }
    public int MakeYear { get; set; }
}

namespace CarRentalSystem.Models;
public class User
{
    required public string Id { get; set; }
    required public string Name { get; set; }
    public string? EmailId { get; set; }
}

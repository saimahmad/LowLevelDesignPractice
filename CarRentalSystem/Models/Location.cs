namespace CarRentalSystem.Models;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public double CalculateDistance(Location location)
    {
        return Math.Pow((Latitude - location.Latitude), 2) + Math.Pow((Longitude - location.Longitude), 2);
    }
}

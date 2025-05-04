namespace CarRentalSystem.Models;

public interface IPricingStrategy
{
    public double CalculatePrice(double basePrice, BookingSlot slot);
}

public class GeneralPricingStrategy : IPricingStrategy
{
    public double CalculatePrice(double basePrice, BookingSlot slot)
    {
        return PricingUtility.CalculateGeneralPrice(basePrice, slot);
    }
}

public class DiscountPricingStrategy : IPricingStrategy
{
    public double CalculatePrice(double basePrice, BookingSlot slot)
    {
        var generalPrice = PricingUtility.CalculateGeneralPrice(basePrice, slot);
        return generalPrice / 2;
    }
}


public static class PricingUtility
{
    public static double CalculateGeneralPrice(double basePrice, BookingSlot slot)
    {
        var totalHours = (slot.EndDate - slot.StartDate).TotalHours;
        return basePrice * Math.Ceiling(totalHours);
    }
}
using CarRentalSystem.Enums;

namespace CarRentalSystem.Models;

public interface IPayment
{
    public void ProcessPayment(double amount);
}


public class UpiPayment : IPayment
{
    public void ProcessPayment(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        Console.WriteLine("Payment done through UPI");
    }
}

public class NetBankingPayment : IPayment
{
    public void ProcessPayment(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        Console.WriteLine("Payment done through NetBanking.");
    }
}

public static class PaymentFactory
{
    public static IPayment CreatePayment(PaymentMode mode)
    {
        switch (mode)
        {
            case PaymentMode.UPI: return new UpiPayment();
            case PaymentMode.NetBanking: return new NetBankingPayment();
            default: throw new ArgumentException("Invalid payment method");
        }
    }
}



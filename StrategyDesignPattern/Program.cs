namespace StrategyDesignPattern;

/*
    The Strategy design pattern is a behavioral design pattern that enables selecting an algorithm's behavior at runtime. This pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. The key idea is to decouple the algorithm from the client that uses it, allowing the algorithm to vary independently from the client.

Components of the Strategy Pattern:

-> Strategy Interface: This defines a common interface for all supported algorithms. The client interacts with the algorithms through this interface, making it easy to switch between different strategies.

-> Concrete Strategies: These are the classes that implement the Strategy interface. Each class provides a specific implementation of the algorithm.

-> Context: This is the class that uses a Strategy. It maintains a reference to a Strategy object and delegates the algorithmic work to that object.

*/


public interface IDiscountStrategy //strategy interface
{
    public decimal ApplyDiscount(decimal price);
}

public class NoDiscountStrategy : IDiscountStrategy  //Concrete Strategies
{
    public decimal ApplyDiscount(decimal price)
    {
        return price;
    }
}

public class PercentageDiscountStrategy : IDiscountStrategy  //Concrete Strategies
{
    private readonly decimal _percentage;

    public PercentageDiscountStrategy(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price - price * (_percentage /100);
    }
}

public class FixedAmountDiscountStrategy : IDiscountStrategy  //Concrete Strategies
{
    private readonly decimal _amount;

    public FixedAmountDiscountStrategy(decimal amount)
    {
        _amount = amount;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price - _amount;
    }
}


public class ShoppingCart
{
    private IDiscountStrategy _discountStrategy = new NoDiscountStrategy();

    public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal GetFinalPrice(decimal price)
    {
        return _discountStrategy.ApplyDiscount(price);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Strategy Design Pattern");

        var cart = new ShoppingCart();

        cart.SetDiscountStrategy(new NoDiscountStrategy());
        Console.WriteLine("No discount amount: " + cart.GetFinalPrice(100m));

        cart.SetDiscountStrategy(new PercentageDiscountStrategy(10));
        Console.WriteLine("10% discount amount: " + cart.GetFinalPrice(100m));

        cart.SetDiscountStrategy(new FixedAmountDiscountStrategy(15));
        Console.WriteLine("$15 discount amount: " + cart.GetFinalPrice(100m));
    }
}


/*
  Benefits of the Strategy Pattern:

   -> Flexibility: You can change the algorithm used by a class at runtime without modifying the class itself.
   -> Single Responsibility Principle: Each strategy class has a single responsibility, making the code easier to understand and maintain.
   -> Open/Closed Principle: The system can be extended with new strategies without modifying the existing code.

Use Cases:
-> When you have multiple algorithms for a specific task and want to switch between them easily.
-> When you want to avoid conditional statements (like if or switch) to select an algorithm.
-> When the algorithm's behavior needs to be selected at runtime based on specific conditions.
 */

namespace DecoratorDesignPattern;


/*
    The Decorator Design Pattern is a structural design pattern that allows behavior to be added to individual objects, either statically or dynamically, without affecting the behavior of other objects from the same class. This pattern is particularly useful for adding functionalities to objects in a flexible and reusable way.

Key Concepts:
    Component Interface: This is the common interface for all objects that can have responsibilities added to them dynamically. Both the base object and decorators will implement this interface.

    Concrete Component: This is the base object to which additional responsibilities can be attached.

    Decorator: This class implements the same interface as the component and contains a reference to a component object. It forwards requests to the component but can also add its own behavior before or after forwarding the request.


Structure:
    Component Interface: Defines the common interface for both the concrete component and decorators.

    Concrete Component: The original object to which you want to add new behaviors.
    Decorator: Implements the component interface and contains a reference to a component object.

    Concrete Decorators: Extends the decorator class and adds specific behaviors to the component.

Example in Code:
    Let’s take an example of a simple coffee order where we want to dynamically add extra ingredients like milk, sugar, etc.
 */

public interface ICoffee
{
    public string GetDescription();
    public int GetCost();
}

public class LatteCoffee : ICoffee
{
    public string GetDescription() => "Latte Coffee";
    public int GetCost() => 100;
}

public class ExpressoCoffee : ICoffee
{
    public string GetDescription() => "Expresso Coffee";
    public int GetCost() => 120;
}

public class CoffeeDecorator : ICoffee
{
    protected ICoffee Coffee { get; set; }

    public CoffeeDecorator(ICoffee coffee)
    {
        Coffee = coffee;
    }

    public virtual string GetDescription() => Coffee.GetDescription();
    public virtual int GetCost() => Coffee.GetCost();
}

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) {}

    public override string GetDescription() => Coffee.GetDescription() + " + Milk";
    public override int GetCost() => Coffee.GetCost() + 25;
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => Coffee.GetDescription() + " + Sugar";
    public override int GetCost() => Coffee.GetCost() + 7;
}

internal class Program
{
    static void Main(string[] args)
    {
        ICoffee coffee = new LatteCoffee();
        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);

        ICoffee coffee2 = new ExpressoCoffee();
        coffee2 = new SugarDecorator(coffee2);
        coffee2 = new SugarDecorator(coffee2);

        Console.WriteLine(coffee.GetDescription() + " : " + coffee.GetCost());
        Console.WriteLine(coffee2.GetDescription() + " : " + coffee2.GetCost());
    }
}

/*
 Advantages:
    Flexibility: The pattern allows adding or removing responsibilities from an object dynamically without modifying its structure.
    Single Responsibility Principle: Functionality is divided among classes, where each class has a single responsibility.
    Reusability: Decorators can be reused across different components.

Disadvantages:
    Complexity: The pattern can lead to a large number of small classes, making the design more complex.
    Dependency: Decorators are tightly coupled with the component they decorate, which can make changes to the system more difficult.
    The Decorator Pattern is ideal when you need to add functionality to an object without altering its interface and want to keep class designs flexible and reusable.
 */

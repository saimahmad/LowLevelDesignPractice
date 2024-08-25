namespace FactoryDesignPattern;

public interface INotification
{
    public void Send(string message);
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sms notificatin sent : {message}");
    }
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email notificatin sent : {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Push notificatin sent : {message}");
    }
}

public static class NotificationFactory
{
    public static INotification CreateNotification(string type)
    {
        switch (type) 
        {
            case "sms": return new SmsNotification();
            case "email": return new EmailNotification();
            case "push": return new PushNotification();
            default : throw new ArgumentException("Notification type invalid");
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var notification1 = NotificationFactory.CreateNotification("sms");
            var notification2 = NotificationFactory.CreateNotification("email");
            var notification3 = NotificationFactory.CreateNotification("push");

            notification1.Send("Product delivered");
            notification2.Send("The product has been delivered successfully.");
            notification3.Send("Product reached!!!!!");

            var notification4 = NotificationFactory.CreateNotification("testError");
            notification4.Send("Error excemption");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }
}

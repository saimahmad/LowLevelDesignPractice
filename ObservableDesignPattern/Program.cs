namespace ObservableDesignPattern;

public interface IStockObservable
{
    public void AddObservable(INotificationAlertObserver observer);

    public void RemoveObservable(INotificationAlertObserver observer);

    public void AddStock(string stockName, int quantity);
}

public class StockObservable : IStockObservable
{
    public List<INotificationAlertObserver> Observers = [];
    public Dictionary<string, int> Products = [];

    public void AddObservable(INotificationAlertObserver observer)
    {
        Observers.Add(observer);
    }

    public void RemoveObservable(INotificationAlertObserver observer)
    {
        Observers.Remove(observer);
    }

    public void AddStock(string stockName, int quantity)
    {
        if(Products.ContainsKey(stockName))
        {
            Products[stockName] += quantity;
        }
        else
        {
            Products.Add(stockName, quantity);
            NotifyAll(stockName);
        }
    }

    void NotifyAll(string stockName)
    {
        foreach(var observer in Observers)
        {
            observer.NotifyUpdate(stockName);
        }
    }
}

public interface INotificationAlertObserver
{
    public void NotifyUpdate(string stock);
}

public class MobileNotificationObserver : INotificationAlertObserver
{
    public string DeviceId { get; set; }

    public MobileNotificationObserver(string deviceId)
    { 
        DeviceId = deviceId; 
    }

    public void NotifyUpdate(string stock)
    {
        Console.WriteLine("Mobile app notification (" + DeviceId + "): " + stock + " is available again.");
    }
}

public class EmailNotificationObserver : INotificationAlertObserver
{
    public string Email {  get; set; }

    public EmailNotificationObserver(string email)
    {
        Email = email;
    }

    public void NotifyUpdate(string stock)
    {
        Console.WriteLine("Email notification (" + Email + "): " + stock + " is available again.");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var emailNotificationObserver = new EmailNotificationObserver("saim.ahmad@gmail.com");
        var mobileNotificationObserver = new MobileNotificationObserver("KA121231");

        var stockObserver = new StockObservable();
        stockObserver.AddObservable(emailNotificationObserver);
        stockObserver.AddObservable(mobileNotificationObserver);

        stockObserver.AddStock("Iphone", 20);
        stockObserver.AddStock("Samsung galaxy", 10);
        stockObserver.AddStock("Iphone", 5);
    }
}

using ElevatorSystemDesign.Enums;

namespace ElevatorSystemDesign.Models;

public class ElevatorCar
{
    public int Id { get; set; }
    public Status Status { get; set; }
    public Direction Direction { get; set; }
    public int Floor { get; set; }
    public InternalButton InternalButton { get; set; }

    public ElevatorCar(int id, InternalButtonDispatcher internalButtonDispatcher) 
    {
        Id = id;
        Status = Status.Inactive;
        Direction = Direction.UP;
        Floor = 0;
        InternalButton = new InternalButton(internalButtonDispatcher, id);
    }


    public async Task Move(int destination, Direction dir)
    {
        Direction = dir;
        Status = Status.Active;
        Console.WriteLine($"Lift {Id} is moving {Direction}...");


        Floor = destination;
        Status = Status.Inactive;
        //Thread.Sleep(1000);
        await Task.Delay(1000);

        Console.WriteLine($"Lift {Id} reached floor {Floor}");
    }

}

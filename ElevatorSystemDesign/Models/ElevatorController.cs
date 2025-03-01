using ElevatorSystemDesign.Enums;

namespace ElevatorSystemDesign.Models;

public class ElevatorController
{
    public required ElevatorCar ElevatorCar { get; set; }

    public async Task AcceptRequest(int destFloor, Direction dir)
    {
       await ElevatorCar.Move(destFloor, dir);
    }
}

using ElevatorSystemDesign.Enums;

namespace ElevatorSystemDesign.Models;

public class InternalButtonDispatcher
{
    public List<ElevatorController>? ElevatorControllers { get; set; }

    public async Task SubmitRequestAsync(int elevatorId, int floor)
    {
        if (ElevatorControllers == null || ElevatorControllers.Count == 0)
            throw new Exception("No elevator controller added");

        var elevatorController = ElevatorControllers
            .FirstOrDefault(_ => _.ElevatorCar.Id  == elevatorId);

        if (elevatorController == null) throw new Exception("Invalid elevator id");

        var dir = GetDirection(elevatorController.ElevatorCar.Floor, floor);

        await elevatorController.AcceptRequest(floor, dir);
    }

    Direction GetDirection(int curFloor, int destFloor)
    {
        return curFloor > destFloor ? Direction.DOWN : Direction.UP;
    }
}

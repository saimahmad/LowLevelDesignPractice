namespace ElevatorSystemDesign.Models;

public class InternalButton
{
    public InternalButtonDispatcher Dispatcher { get; set; }
    public int ElevatorId { get; set; }

    public InternalButton(InternalButtonDispatcher dispatcher, int elevatorId)
    {
        Dispatcher = dispatcher;
        ElevatorId = elevatorId;
    }

    public async Task PressButton(int floor)
    {
        await Dispatcher.SubmitRequestAsync(ElevatorId, floor);
    }
}

using ElevatorSystemDesign.Models;

namespace ElevatorSystemDesign
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var internalButtonDispatcher = new InternalButtonDispatcher();

            var elevatorControllers = new List<ElevatorController>()
            {
                new()
                {
                    ElevatorCar = new ElevatorCar(1, internalButtonDispatcher)
                },
                  new()
                {
                    ElevatorCar = new ElevatorCar(2, internalButtonDispatcher)
                },
            };

            internalButtonDispatcher.ElevatorControllers = elevatorControllers;

            await elevatorControllers[0].ElevatorCar.InternalButton.PressButton(5);
            await elevatorControllers[0].ElevatorCar.InternalButton.PressButton(3);
        }
    }
}

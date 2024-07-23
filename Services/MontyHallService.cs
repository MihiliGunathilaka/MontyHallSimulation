// Services/MontyHallService.cs
using System;

public class MontyHallService
{
    public SimulationResult RunSimulations(int numberOfSimulations, bool switchDoor)
    {
        int winsWithSwitching = 0;
        int winsWithoutSwitching = 0;
        Random rand = new Random();

        for (int i = 0; i < numberOfSimulations; i++)
        {
            bool[] doors = { false, false, false };
            int carDoor = rand.Next(3);
            doors[carDoor] = true;

            int playerChoice = rand.Next(3);

            int revealedDoor;
            do
            {
                revealedDoor = rand.Next(3);
            } while (revealedDoor == playerChoice || doors[revealedDoor]);

            int finalChoice = switchDoor ? 3 - playerChoice - revealedDoor : playerChoice;

            if (doors[finalChoice])
            {
                if (switchDoor) winsWithSwitching++;
                else winsWithoutSwitching++;
            }
        }

        return new SimulationResult
        {
            TotalSimulations = numberOfSimulations,
            WinsWithSwitching = winsWithSwitching,
            WinsWithoutSwitching = winsWithoutSwitching
        };
    }
}

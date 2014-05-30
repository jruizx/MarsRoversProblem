using System;
using System.IO;
using MarsRovers;

namespace MarsController
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "Mission.txt";

            using (var streamReader = File.OpenText(fileName))
            {
                var line = streamReader.ReadLine();

                if (line != null)
                {
                    var plateau = Plateau.CreatePlateau(line);
                    var count = 0;
                    Rover rover = null;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (count % 2 == 0)
                        {
                            rover = Rover.CreateRover(line);
                            rover.SetPlateau(plateau);
                        }
                        else
                        {
                            rover.ExecuteBatchCommands(line);
                            Console.WriteLine(rover.GetPosition());
                        }

                        count++;
                    }
                }
            }
        }
    }
}

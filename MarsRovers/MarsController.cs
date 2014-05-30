using System;
using System.IO;

namespace MarsRovers
{
    public static class MarsController
    {
        public static void Start(string fileName)
        {
            using (var streamReader = File.OpenText(fileName))
            {
                var line = streamReader.ReadLine();

                if(line != null)
                {
                    var plateau = CreatePlateau(line);
                    var count = 0;
                    Rover rover = null;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if(count % 2 == 0)
                        {
                            rover = CreateRover(line);
                            rover.SetPlateau(plateau);
                        }
                        else
                        {
                            ExecutadCommands(rover, line);
                            Console.WriteLine(rover.GetPosition());
                        }

                        count++;
                    }
                }
            }
        }

        private static Plateau CreatePlateau(string definition)
        {
            var stringCoordinates = definition.Split(' ');

            var coordinates = new Coordinates(Convert.ToInt32(stringCoordinates[0]),
                                              Convert.ToInt32(stringCoordinates[1]));

            return new Plateau(coordinates);
        }

        private static Rover CreateRover(string definition)
        {
            var coordinatesAndOrientation = definition.Split(' ');

            var coordinates = new Coordinates(Convert.ToInt32(coordinatesAndOrientation[0]),
                                              Convert.ToInt32(coordinatesAndOrientation[1]));

            var orientation = OrientationFactory.GenerateOrientation(coordinatesAndOrientation[3]);

            var rover = new Rover();
            rover.Init(coordinates, orientation);

            return rover;
        }

        private static void ExecutadCommands(Rover rover, string stringCommands)
        {
            foreach (var command in stringCommands)
            {
                switch(command)
                {
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                    case 'M':
                        rover.Move();
                        break;
                }
            }
        }
    }
}

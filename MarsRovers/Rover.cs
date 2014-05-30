using System;
using MarsRovers.Exceptions;

namespace MarsRovers
{
    public class Rover
    {
        private Coordinates coordinates;
        private IOrientation orientation;
        private Plateau plateau;

        public Rover()
        {
            orientation = new NoOrientation();
        }

        public void Init(Coordinates coordinates, IOrientation orientation)
        {
            this.coordinates = coordinates;
            this.orientation = orientation;
        }

        public IOrientation Orientation
        {
            get { return orientation; }
        }

        public Coordinates Coordinates
        {
            get { return coordinates; }
        }

        public void SetPlateau(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public void TurnLeft()
        {
            orientation = Orientation.TurnLeft();
        }

        public void TurnRight()
        {
            orientation = Orientation.TurnRight();
        }

        public string GetPosition()
        {
            return string.Format("{0} {1}", coordinates, orientation);
        }

        public void Move()
        {
            var nextPosition = orientation.Advance(coordinates);

            if(plateau != null)
            {
                if(!plateau.AreCoordinatesInside(nextPosition)) throw new OutOfPlateauException("Rover can't advance out of the plateau.");
            }

            coordinates = nextPosition;
        }

        public void ExecuteBatchCommands(string stringCommands)
        {
            foreach (var command in stringCommands)
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        throw new UnknownCommandException(string.Format("The command '{0}' is unknown.", command));
                }
            }
        }

        public static Rover CreateRover(string definition)
        {
            if (string.IsNullOrEmpty(definition)) throw new WrongRoverDefinitionException("Definition of rover is empty.");

            var coordinatesAndOrientation = definition.Split(' ');

            if(coordinatesAndOrientation.Length != 3) throw new WrongRoverDefinitionException("Definition of rover doesn't have the proper format.");

            Coordinates coordinates;
            IOrientation orientation;

            try
            {
                coordinates = new Coordinates(Convert.ToInt32(coordinatesAndOrientation[0]),
                                                  Convert.ToInt32(coordinatesAndOrientation[1]));

                orientation = OrientationFactory.GenerateOrientation(coordinatesAndOrientation[2]);
            }
            catch (Exception ex)
            {
                throw new WrongRoverDefinitionException("Bad definition.", ex);
            }

            var rover = new Rover();

            rover.Init(coordinates, orientation);

            return rover;
        }
    }
}
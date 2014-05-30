using MarsRovers.Exceptions;
using NUnit.Framework;

namespace MarsRovers.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Init_InitialCoordinatesAndOrientation_RoverCoordinatesMustBeEqualToInitialCoordinates()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            var endCoordinates = new Coordinates(0, 0);
            var orientation = new NorthOrientation();

            // Act
            rover.Init(initialCoordinates, orientation);

            // Asset
            Assert.That(rover.Coordinates, Is.EqualTo(endCoordinates));
        }

        [Test]
        public void Init_InitialCoordinatesAndOrientation_RoverOrientationMustBeEqualToInitialOrientation()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            var orientation = new NorthOrientation();
            var finalOrientation = new NorthOrientation();

            // Act
            rover.Init(initialCoordinates, orientation);

            // Asset
            Assert.That(rover.Orientation, Is.EqualTo(finalOrientation));
        }

        [Test]
        public void TurnLeft_InitialOrientationIsNorth_FinalOrientationShouldBeWest()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new NorthOrientation());

            // Act
            rover.TurnLeft();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new WestOrientation()));
        }

        [Test]
        public void TurnLeft_InitialOrientationIsWest_FinalOrientationShouldBeSouth()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new WestOrientation());

            // Act
            rover.TurnLeft();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new SouthOrientation()));
        }

        [Test]
        public void TurnLeft_InitialOrientationIsSouth_FinalOrientationShouldBeEast()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new SouthOrientation());

            // Act
            rover.TurnLeft();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new EastOrientation()));
        }

        [Test]
        public void TurnLeft_InitialOrientationIsEast_FinalOrientationShouldBeNorth()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new EastOrientation());

            // Act
            rover.TurnLeft();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new NorthOrientation()));
        }

        [Test]
        public void TurnRight_InitialOrientationIsNorth_FinalOrientationShouldBeEast()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new NorthOrientation());

            // Act
            rover.TurnRight();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new EastOrientation()));
        }

        [Test]
        public void TurnRight_InitialOrientationIsWest_FinalOrientationShouldBeNorth()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new WestOrientation());

            // Act
            rover.TurnRight();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new NorthOrientation()));
        }

        [Test]
        public void TurnRight_InitialOrientationIsSouth_FinalOrientationShouldBeWest()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new SouthOrientation());

            // Act
            rover.TurnRight();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new WestOrientation()));
        }

        [Test]
        public void TurnRight_InitialOrientationIsEast_FinalOrientationShouldBeSouth()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new EastOrientation());

            // Act
            rover.TurnRight();

            //Assert
            Assert.That(rover.Orientation, Is.EqualTo(new SouthOrientation()));
        }

        [Test]
        public void Move_InitialStateIs00N_FinalStateShouldBe01N()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new NorthOrientation());

            // Act
            rover.Move();

            //Assert
            Assert.That(rover.Coordinates, Is.EqualTo(new Coordinates(0, 1)));
        }

        [Test]
        public void Move_InitialStateIs00E_FinalStateShouldBe10E()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new EastOrientation());

            // Act
            rover.Move();

            //Assert
            Assert.That(rover.Coordinates, Is.EqualTo(new Coordinates(1, 0)));
        }

        [Test]
        public void Move_InitialStateIs01S_FinalStateShouldBe00S()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 1);
            rover.Init(initialCoordinates, new SouthOrientation());

            // Act
            rover.Move();

            //Assert
            Assert.That(rover.Coordinates, Is.EqualTo(new Coordinates(0, 0)));
        }

        [Test]
        public void Move_InitialStateIs10W_FinalStateShouldBe00W()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(1, 0);
            rover.Init(initialCoordinates, new WestOrientation());

            // Act
            rover.Move();

            //Assert
            Assert.That(rover.Coordinates, Is.EqualTo(new Coordinates(0, 0)));
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs00WAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new WestOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs00SAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 0);
            rover.Init(initialCoordinates, new SouthOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs50EAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(5, 0);
            rover.Init(initialCoordinates, new EastOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs50SAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(5, 0);
            rover.Init(initialCoordinates, new SouthOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs55NAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(5, 5);
            rover.Init(initialCoordinates, new NorthOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs55EAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(5, 5);
            rover.Init(initialCoordinates, new EastOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs05NAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 5);
            rover.Init(initialCoordinates, new NorthOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void Move_InitialStateIs05WAndPlateauIsSetTo55_OutOfPlateauException()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(0, 5);
            rover.Init(initialCoordinates, new WestOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();
        }

        [Test]
        public void Move_InitialStateIs33WAndPlateauIsSetTo55_TheNewCoordinatesShouldBe23W()
        {
            // Arrange
            var rover = new Rover();
            var initialCoordinates = new Coordinates(3, 3);
            rover.Init(initialCoordinates, new WestOrientation());

            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);

            rover.SetPlateau(plateau);

            // Act
            rover.Move();

            // Assert
            Assert.That(rover.Coordinates, Is.EqualTo(new Coordinates(2, 3)));
            Assert.That(rover.Orientation, Is.EqualTo(new WestOrientation()));
        }

        [Test]
        [ExpectedException(typeof(WrongRoverDefinitionException))]
        public void CreateRover_EmptyDefinition_WrongRoverDefinitionException()
        {
            // Act
            Rover.CreateRover("");
        }

        [Test]
        [ExpectedException(typeof(WrongRoverDefinitionException))]
        public void CreateRover_NoNumbersInTheFirstTwoPositionsDefinition_WrongRoverDefinitionException()
        {
            // Act
            Rover.CreateRover("N N N");
        }

        [Test]
        [ExpectedException(typeof(WrongRoverDefinitionException))]
        public void CreateRover_WrongOrientation_WrongRoverDefinitionException()
        {
            // Act
            Rover.CreateRover("5 5 H");
        }

        [Test]
        public void CreateRover_55N_WeShouldRetrieveANewRoverWith55NCoordinatesAndFacing()
        {
            // Act
            var rover = Rover.CreateRover("5 5 N");

            // Assert
            Assert.That(rover.Orientation, Is.EqualTo(new NorthOrientation()));
            Assert.That(rover.Coordinates, Is.EqualTo(new Coordinates(5, 5)));
        }

        [Test]
        [ExpectedException(typeof(UnknownCommandException))]
        public void ExecuteBatchCommands_UnknownCommands_UnknownCommandException()
        {
            // Arrange
            var rover = Rover.CreateRover("5 5 N");

            // Act
            rover.ExecuteBatchCommands("S");
        }
    }
}

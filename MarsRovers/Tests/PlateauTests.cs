using MarsRovers.Exceptions;
using NUnit.Framework;

namespace MarsRovers.Tests
{
    [TestFixture]
    public class PlateauTests
    {
        [Test]
        public void AreCoordinatesInside_Plateau55AndCoordinates33_TheMethodShouldReturnTrue()
        {
            // Arrange
            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);
            var coordinatesToCheck = new Coordinates(3, 3);

            // Act
            var result = plateau.AreCoordinatesInside(coordinatesToCheck);

            // Assert
            Assert.That(result, Is.True);
        }


        [Test]
        public void AreCoordinatesInside_Plateau55AndCoordinates00_TheMethodShouldReturnTrue()
        {
            // Arrange
            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);
            var coordinatesToCheck = new Coordinates(0, 0);

            // Act
            var result = plateau.AreCoordinatesInside(coordinatesToCheck);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void AreCoordinatesInside_Plateau55AndCoordinates55_TheMethodShouldReturnTrue()
        {
            // Arrange
            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);
            var coordinatesToCheck = new Coordinates(5, 5);

            // Act
            var result = plateau.AreCoordinatesInside(coordinatesToCheck);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void AreCoordinatesInside_Plateau55AndCoordinates56_TheMethodShouldReturnFalse()
        {
            // Arrange
            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);
            var coordinatesToCheck = new Coordinates(5, 6);

            // Act
            var result = plateau.AreCoordinatesInside(coordinatesToCheck);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void AreCoordinatesInside_Plateau55AndCoordinates65_TheMethodShouldReturnFalse()
        {
            // Arrange
            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);
            var coordinatesToCheck = new Coordinates(6, 5);

            // Act
            var result = plateau.AreCoordinatesInside(coordinatesToCheck);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void AreCoordinatesInside_Plateau55AndCoordinatesMinus15_TheMethodShouldReturnFalse()
        {
            // Arrange
            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);
            var coordinatesToCheck = new Coordinates(-1, 5);

            // Act
            var result = plateau.AreCoordinatesInside(coordinatesToCheck);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void AreCoordinatesInside_Plateau55AndCoordinates5Minus1_TheMethodShouldReturnFalse()
        {
            // Arrange
            var upperLeft = new Coordinates(5, 5);
            var plateau = new Plateau(upperLeft);
            var coordinatesToCheck = new Coordinates(5, -1);

            // Act
            var result = plateau.AreCoordinatesInside(coordinatesToCheck);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        [ExpectedException(typeof(WrongPlateauDefinitionException))]
        public void CreatePlateau_WrongDefinition_WrongDefinitionException()
        {
            // Act
            Plateau.CreatePlateau("");
        }

        [Test]
        [ExpectedException(typeof(WrongPlateauDefinitionException))]
        public void CreatePlateau_NN_WrongDefinitionException()
        {
            // Act
            Plateau.CreatePlateau("N N");
        }

        [Test]
        public void CreatePlateau_55_ThePlateauCoordinatesShouldBe55()
        {
            // Act
            var plateau = Plateau.CreatePlateau("5 5");

            // Assert
            Assert.That(plateau.UpperLeft, Is.EqualTo(new Coordinates(5, 5)));
        }
    }
}

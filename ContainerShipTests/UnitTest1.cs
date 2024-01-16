using ContainerSchip.Classes;
using ContainerSchip.Interfaces;

namespace ContainerShipTests
{
    public class UnitTest1
    {
        [Fact]
        public void IsTopContainer_ContainerIsTop_ReturnsTrue()
        {
            // Arrange
            var shipData = new IContainer[1, 1, 2];
            shipData[0, 0, 1] = new ValuableContainer(); // Only container at top

            // Act
            bool result = shipData[0, 0, 1].IsTopContainer(0, 0, 1, shipData);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsTopContainer_ContainerNotTop_ReturnsFalse()
        {
            // Arrange
            var shipData = new IContainer[1, 1, 2];
            shipData[0, 0, 0] = new ValuableContainer();
            shipData[0, 0, 1] = new NormalContainer(); // Container not at top

            // Act
            bool result = shipData[0, 0, 0].IsTopContainer(0, 0, 0, shipData);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasContainerInFront_ContainerInFront_ReturnsTrue()
        {
            // Arrange
            var shipData = new IContainer[2, 1, 1];
            shipData[0, 0, 0] = new ValuableContainer(); // Container in front
            shipData[1, 0, 0] = new ValuableContainer(); // Target container

            // Act
            bool result = shipData[1, 0, 0].HasContainerInFront(1, 0, 0, shipData);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasContainerInFront_ContainerAtFront_ReturnsFalse()
        {
            // Arrange
            var shipData = new IContainer[2, 1, 1];
            shipData[1, 0, 0] = new ValuableContainer(); // Container at frontmost position

            // Act
            bool result = shipData[0, 0, 0].HasContainerInFront(0, 0, 0, shipData);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasContainerBehind_ContainerBehind_ReturnsTrue()
        {
            // Arrange
            var shipData = new IContainer[2, 1, 1];
            shipData[0, 0, 0] = new ValuableContainer(); // Target container
            shipData[1, 0, 0] = new ValuableContainer(); // Container behind

            // Act
            bool result = shipData[0, 0, 0].HasContainerBehind(0, 0, 0, shipData);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasContainerBehind_ContainerAtBack_ReturnsFalse()
        {
            // Arrange
            var shipData = new IContainer[2, 1, 1];
            shipData[0, 0, 0] = new ValuableContainer(); // Container at backmost position

            // Act
            bool result = shipData[1, 0, 0].HasContainerBehind(1, 0, 0, shipData);

            // Assert
            Assert.False(result);
        }



    }
}
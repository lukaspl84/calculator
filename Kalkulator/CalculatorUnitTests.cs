using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kalkulator
{
    [TestClass]
    public class CalculatorUnitTests
    {
        [TestMethod]
        public void OperationCalculation_AddOperation_ShouldReturnCorrectValue()
        {
            // Arrange
            var a = new Kalkulator();
            var parameterA = 5;
            var parameterB = 10;
            byte operationType = 1;

            // Act
            var result = a.OperationCalculation(parameterA, parameterB, operationType);

            // Assert
            result.Should().Be(15);
        }

        [TestMethod]
        public void OperationCalculation_SubstractOperation_ShouldReturnCorrectValue()
        {
            // Arrange
            var a = new Kalkulator();
            var parameterA = 5;
            var parameterB = 10;
            byte operationType = 2;

            // Act
            var result = a.OperationCalculation(parameterA, parameterB, operationType);

            // Assert
            result.Should().Be(-5);
        }

        [TestMethod]
        public void OperationCalculation_MultipleOperation_ShouldReturnCorrectValue()
        {
            // Arrange
            var a = new Kalkulator();
            var parameterA = 5;
            var parameterB = 10;
            byte operationType = 3;

            // Act
            var result = a.OperationCalculation(parameterA, parameterB, operationType);

            // Assert
            result.Should().Be(50);
        }

        [TestMethod]
        public void OperationCalculation_DivideOperation_ShouldReturnCorrectValue()
        {
            // Arrange
            var a = new Kalkulator();
            var parameterA = 15;
            var parameterB = 5;
            byte operationType = 4;

            // Act
            var result = a.OperationCalculation(parameterA, parameterB, operationType);

            // Assert
            result.Should().Be(3);
        }
    }
}

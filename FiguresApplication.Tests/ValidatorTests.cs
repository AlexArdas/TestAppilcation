using FiguresApplication.Validators;
using GeometryHelper.Figures;
using Xunit;

namespace FiguresApplication.Tests
{
    /// <summary>
    /// Класс тестов для проверки валидации
    /// </summary>
    public class ValidatorTests
    {
        [Theory]
        [InlineData("5", 5)]
        [InlineData("3.14", 3.14)]
        [InlineData("0.001", 0.001)]
        public void GetValidValue_ShouldReturnValidDouble_WhenInputIsValid(string input, double expected)
        {
            // Act
            var result = ShapeValidator.GetValidValue(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("pup")]
        [InlineData("1.23.45")]
        [InlineData("")]
        public void GetValidValue_ShouldThrowArgumentException_WhenInputIsInvalid(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>
                (() => ShapeValidator.GetValidValue(input));
        }

        [Theory]
        [InlineData(new double[] { -1, 4, 5 })]
        [InlineData(new double[] { 3, -4, 5 })]
        [InlineData(new double[] { 3, 4, -5 })]
        [InlineData(new double[] { 0, 4, 5 })]
        public void ValidateTriangle_ShouldThrowArgumentException_WhenInvalidSides(double[] sides)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>
                (() => ShapeValidator.ValidateTriangle(sides));
        }

        [Theory]
        [InlineData(new double[] { 1, 1 })]
        [InlineData(new double[] { 1, 1, 1, 1 })]
        public void ValidateTriangle_ShouldThrowArgumentException_WhenIncorrectNumberOfSides(double[] sides)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>
                (() => ShapeValidator.ValidateTriangle(sides));
        }

        [Theory]
        [InlineData(new double[] { 1, 2, 10 })]
        [InlineData(new double[] { 2, 5, 20 })]
        public void ValidateTriangle_ShouldThrowArgumentException_WhenSuchATriangleCannotExist(double[] sides)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>
                (() => ShapeValidator.ValidateTriangle(sides));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        [InlineData(-10)]
        public void ValidateCircle_ShouldThrowArgumentException_WhenInvalidRadius(double radius)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>
                (() => ShapeValidator.ValidateCircle(radius));
        }
    }
}

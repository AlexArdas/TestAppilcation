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
        /// <summary>
        /// Проверяет возвращает ли метод GetValidValue корректное значение double при валидном вводе
        /// </summary>
        /// <param name="input">Входное значение</param>
        /// <param name="expected">Ожидаемое значение</param>
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

        /// <summary>
        /// Проверяет выбрасывает ли метод GetValidValue исключение ArgumentException при невалидном вводе
        /// </summary>
        /// <param name="input">Входное значение</param>
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

        /// <summary>
        /// Проверяет выбрасывает ли метод ValidateTriangle исключение ArgumentException при невалидных сторонах треугольника
        /// </summary>
        /// <param name="sides">Массив значений сторон треугольника</param>
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

        /// <summary>
        /// Проверяет выбрасывает ли метод ValidateTriangle исключение ArgumentException при некорректном числе сторон треугольника
        /// </summary>
        /// <param name="sides">Массив значений сторон треугольника</param>
        [Theory]
        [InlineData(new double[] { 1, 1 })]
        [InlineData(new double[] { 1, 1, 1, 1 })]
        public void ValidateTriangle_ShouldThrowArgumentException_WhenIncorrectNumberOfSides(double[] sides)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>
                (() => ShapeValidator.ValidateTriangle(sides));
        }

        /// <summary>
        /// Проверяет выбрасывает ли метод ValidateTriangle исключение ArgumentException при невозможности существования треугольника
        /// </summary>
        /// <param name="sides">Массив значений сторон треугольника</param>
        [Theory]
        [InlineData(new double[] { 1, 2, 10 })]
        [InlineData(new double[] { 2, 5, 20 })]
        public void ValidateTriangle_ShouldThrowArgumentException_WhenSuchATriangleCannotExist(double[] sides)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>
                (() => ShapeValidator.ValidateTriangle(sides));
        }

        /// <summary>
        /// Проверяет выбрасывает ли метод ValidateCircle исключение ArgumentException при невалидном радиусе
        /// </summary>
        /// <param name="radius">Значение радиуса</param>
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

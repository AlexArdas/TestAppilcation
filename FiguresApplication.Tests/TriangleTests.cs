using AutoFixture;
using GeometryHelper.Figures;
using Shouldly;
using System;

namespace FiguresApplication.Tests
{
    /// <summary>
    /// Тесты для класса Triangle
    /// </summary>
    public class TriangleTests
    {
        private readonly Fixture _fixture;

        /// <summary>
        /// Инициализирует новый экземпляр класса TriangleTests
        /// </summary>
        public TriangleTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void CalculateArea_ShouldCalculateArea()
        {
            // Arrange
            var side1 = _fixture.Create<double>();
            var side2 = _fixture.Create<double>();
            var side3 = _fixture.Create<double>();
            var triangle = new Triangle(side1, side2, side3);

            var s = (side1 + side2 + side3) / 2;
            var expectedArea = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));

            // Act
            var area = triangle.CalculateArea();

            // Assert
            area.ShouldBe(expectedArea);
        }

        [Fact]
        public void IsRightAngled_ShouldReturnTrueForRightAngleTriangle()
        {
            // Arrange
            var side1 = 3;
            var side2 = 4;
            var side3 = 5;
            var triangle = new Triangle(side1, side2, side3);

            // Act
            var isRightAngled = triangle.IsRightAngled();

            // Assert
            isRightAngled.ShouldBeTrue();
        }

        [Fact]
        public void IsRightAngled_ShouldReturnFalseForRightAngleTriangle()
        {
            // Arrange
            var side1 = 3;
            var side2 = 4;
            var side3 = 6;
            var triangle = new Triangle(side1, side2, side3);

            // Act
            var isRightAngled = triangle.IsRightAngled();

            // Assert
            isRightAngled.ShouldBeFalse();
        }

    }
}

using AutoFixture;
using GeometryHelper.Figures;
using Shouldly;

namespace FiguresApplication.Tests
{
    /// <summary>
    /// Тесты для класса Circle.
    /// </summary>
    public class CircleTests
    {
        private readonly Fixture _fixture;

        /// <summary>
        /// Инициализирует новый экземпляр класса CircleTests.
        /// </summary>
        public CircleTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void CalculateArea_ShouldCalculateArea()
        {
            //Arrange
            var radius = _fixture.Create<uint>();
            var expectedArea = Math.PI * radius * radius;

            //Act
            var area = new Circle(radius).CalculateArea(); 

            //Assert
            area.ShouldBe(expectedArea);
        }
    }
}

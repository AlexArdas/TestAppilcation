using AutoFixture;
using GeometryHelper;
using GeometryHelper.Enum;
using GeometryHelper.Figures;
using Shouldly;

namespace FiguresApplication.Tests
{
    public class ShapeFactoryTests
    {
        private readonly Fixture _fixture;

        public ShapeFactoryTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void CreateShape_ShouldCreateCircle()
        {
            //Arrange
            var radius = _fixture.Create<uint>();
            var shapeType = ShapeType.Circle;

            var expectedCircle = new Circle(radius);

            //Act
            var circle = (Circle)ShapeFactory.CreateShape(shapeType, radius);

            //Assert
            circle.ShouldBe(expectedCircle);
        }

        [Fact]
        public void CreateShape_ShouldCreateTriangle()
        {
            //Arrange
            var side1 = _fixture.Create<uint>();
            var side2 = _fixture.Create<uint>();
            var side3 = side1 + side2 - 1;
            var shapeType = ShapeType.Triangle;

            var expectedTriangle = new Triangle(side1, side2, side3);

            //Act
            var triangle = (Triangle)ShapeFactory.CreateShape(shapeType, side1, side2, side3);

            //Assert
            triangle.ShouldBe(expectedTriangle);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(new double[0])]
        public void CrateTriangle_ShouldThrowArgumentNullException_WhenPropertiesIsNull(double[] properties)
        {
            //Arrange
            var shapeType = _fixture.Create<ShapeType>();

            //Act
            var func = () => ShapeFactory.CreateShape(shapeType, properties);

            //Assert
            func.ShouldThrow<ArgumentNullException>()
                .Message.ShouldContain($"{properties} не должны быть пустыми");
        }

        [Fact]
        public void CrateTriangle_ShouldThrowArgumentException_WhenMessageTypeUncnown()
        {
            //Arrange
            var shapeType = (ShapeType)3;
            var properties = _fixture.Create<double[]>();

            //Act
            var func = () => ShapeFactory.CreateShape(shapeType, properties);

            //Assect
            func.ShouldThrow<ArgumentException>()
                 .Message.ShouldBe("Неизвестный тип фигуры");
        }
    }
}
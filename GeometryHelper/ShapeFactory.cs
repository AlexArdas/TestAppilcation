using FiguresApplication.Validators;
using GeometryHelper.Enum;
using GeometryHelper.Figures;
using GeometryHelper.Interface;

namespace GeometryHelper
{
    /// <summary>
    /// Фабрика для создания экземпляров различных фигур
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// Создает экземпляр фигуры указанного типа с заданными параметрами
        /// </summary>
        /// <param name="type">Тип фигуры.</param>
        /// <param name="properties">Параметры фигуры (например, радиус для круга или стороны для треугольника)</param>
        /// <returns>Экземпляр фигуры</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если параметры фигуры не указаны</exception>
        /// <exception cref="ArgumentException">Выбрасывается, если тип фигуры неизвестен</exception>
        public static IShape CreateShape(ShapeType type, params double[] properties)
        {

            if(properties is null || !properties.Any())
                throw new ArgumentNullException($"{properties} не должны быть пустыми");

            switch (type)
            {
                case ShapeType.Circle:
                    var radius = properties.FirstOrDefault();
                    ShapeValidator.ValidateCircle(radius);
                    return CreateCircle(radius);
                case ShapeType.Triangle:
                    ShapeValidator.ValidateTriangle(properties);
                    return CreateTriangle(properties[0], properties[1], properties[2]);
                default:
                    throw new ArgumentException("Неизвестный тип фигуры");
            }
        }

        /// <summary>
        /// Создает экземпляр круговой фигуры с заданным радиусом
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <returns>Экземпляр круговой фигуры</returns>
        private static Circle CreateCircle(double radius)
        {
            return new Circle(radius);
        }

        /// <summary>
        /// Создает экземпляр треугольной фигуры с заданными сторонами
        /// </summary>
        /// <param name="side1">Длина первой стороны треугольника</param>
        /// <param name="side2">Длина второй стороны треугольника</param>
        /// <param name="side3">Длина третьей стороны треугольника</param>
        /// <returns>Экземпляр треугольной фигуры</returns>
        private static Triangle CreateTriangle(double side1, double side2, double side3)
        {
            return new Triangle(side1, side2, side3);
        }
    }
}


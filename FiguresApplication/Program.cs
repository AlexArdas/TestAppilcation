using GeometryHelper;
using GeometryHelper.Enum;
using GeometryHelper.Figures;

namespace FiguresApplication
{
    /// <summary>
    /// Основной класс программы для работы с пользователем
    /// </summary>
    class Program
    {
        // <summary>
        /// Главный метод программы точка входа
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            try
            {
                var shapeType = ConsoleHelper.InputFromConsole<ShapeType>();

                switch (shapeType)
                {
                    case ShapeType.Circle:
                        CalculateCircleArea();
                        break;
                    case ShapeType.Triangle:
                        var operationType = ConsoleHelper.InputFromConsole<OperationType>();
                        var sides = ConsoleHelper.InputTriangleSides();
                        var triangle = ShapeFactory.CreateShape(ShapeType.Triangle, sides);
                        switch (operationType)
                        {
                            case OperationType.CalculateArea:
                                CalculateTriangleArea((Triangle)triangle);
                                break;
                            case OperationType.CheckIsRightAngled:
                                CheckTriangleISRightAngle((Triangle)(triangle));
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

        }

        /// <summary>
        /// Вычисляет площадь круга и выводит результат на консоль
        /// </summary>
        private static void CalculateCircleArea()
        {
            var radius = ConsoleHelper.InputCircleRadius();

            var circle = ShapeFactory.CreateShape(ShapeType.Circle, radius);
            Console.WriteLine($"Площадь круга с радиусом {radius} равна: {circle.CalculateArea()}");
        }

        /// <summary>
        /// Вычисляет площадь треугольника и выводит результат на консоль
        /// </summary>
        /// <param name="triangle">Треугольник, для которого нужно вычислить площадь.</param>
        private static void CalculateTriangleArea(Triangle triangle)
        {
            Console.WriteLine($"Площадь треугольника со сторонами {triangle.Side1}, {triangle.Side2} и {triangle.Side3} равна: {triangle.CalculateArea()}");
        }

        /// <summary>
        /// Проверяет является ли треугольник прямоугольным и выводит результат на консоль
        /// </summary>
        /// <param name="triangle">Треугольник, который нужно проверить.</param>
        private static void CheckTriangleISRightAngle(Triangle triangle)
        {
            Console.WriteLine($"Треуголник со сторонами {triangle.Side1}, {triangle.Side2} и {triangle.Side3} прямоугольный: ");
        }
    }
}

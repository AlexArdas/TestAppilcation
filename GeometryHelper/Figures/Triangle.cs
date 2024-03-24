using GeometryHelper.Interface;

namespace GeometryHelper.Figures
{
    /// <summary>
    /// Представляет треугольник
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Длина первой стороны треугольника.
        /// </summary>
        public double Side1 { get; }

        /// <summary>
        /// Длина второй стороны треугольника.
        /// </summary>
        public double Side2 { get; }

        /// <summary>
        /// Длина третьей стороны треугольника.
        /// </summary>
        public double Side3 { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Triangle с указанными сторонами.
        /// </summary>
        /// <param name="side1">Длина первой стороны треугольника.</param>
        /// <param name="side2">Длина второй стороны треугольника.</param>
        /// <param name="side3">Длина третьей стороны треугольника.</param>
        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона
        /// </summary>
        /// <returns>Площадь треугольника.</returns>

        public double CalculateArea()
        {
            var s = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>true, если треугольник прямоугольный; в противном случае - false.</returns>
        public bool IsRightAngled()
        {
            double[] sides = { Side1, Side2, Side3 };
            Array.Sort(sides);

            var a = sides[0];
            var b = sides[1];
            var c = sides[2];

            return (a * a + b * b == c * c) || (a * a + c * c == b * b) || (c * c + b * b == a * a);
        }

        /// <summary>
        /// Сравнивает данный объект с другим объектом и определяет равны ли они
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>true, если объекты равны; в противном случае - false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var triangle = obj as Triangle;

            return triangle.Side1 == Side1 && triangle.Side2 == Side2 && triangle.Side3 == Side3;
        }

        /// <summary>
        /// Возвращает хэш-код для данного объекта
        /// </summary>
        /// <returns>Хэш-код.</returns>
        public override int GetHashCode()
        {
            return Side1.GetHashCode() + Side2.GetHashCode() + Side3.GetHashCode();
        }
    }
}

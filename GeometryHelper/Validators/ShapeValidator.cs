namespace FiguresApplication.Validators
{
    /// <summary>
    /// Предоставляет методы для проверки валидности значений и параметров фигур
    /// </summary>
    public static class ShapeValidator
    {
        /// <summary>
        /// Получает допустимое числовое значение из входной строки
        /// </summary>
        /// <param name="inputedValue">Входное значение</param>
        /// <returns>Допустимое числовое значение.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если входное значение не является числом</exception>
        public static double GetValidValue(string inputedValue)
        {

            var isNumber = double.TryParse(inputedValue, out double number);

            if (!isNumber)
                throw new ArgumentException("Неккоректный ввод");

            return number;
        }

        /// <summary>
        /// Проверяет являются ли заданные значения сторон допустимыми для треугольника
        /// </summary>
        /// <param name="sides">Массив значений сторон треугольника</param>
        /// <exception cref="ArgumentException">Выбрасывается если заданные значения не являются допустимыми сторонами треугольника</exception>
        public static void ValidateTriangle(double[] sides)
        {

            if (sides.Any(s => s <= 0))
                throw new ArgumentException("Стороны треугольнитка должны быть положительными");

            if (sides.Length != 3)
                throw new ArgumentException("Для треугольника нужно 3 строны");

            if (sides[0] >= sides[1] + sides[2]
                || sides[1] >= sides[0] + sides[2]
                || sides[2] >= sides[0] + sides[1])
                throw new ArgumentException("Треуголник с такими сторонами не существует");
        }

        /// <summary>
        /// Проверяет является ли заданное значение радиуса допустимым для круга
        /// </summary>
        /// <param name="radius">Значение радиуса</param>
        /// <exception cref="ArgumentException">Выбрасывается если заданное значение не является допустимым радиусом круга</exception>
        public static void ValidateCircle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус круга должен быть положительным");
        }
    }
}

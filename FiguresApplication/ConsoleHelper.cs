using FiguresApplication.Validators;

namespace FiguresApplication
{
    /// <summary>
    /// Класс для ввода данных из консоли
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Ввод радиуса круга из консоли
        /// </summary>
        /// <returns>Радиус круга</returns>
        public static double InputCircleRadius()
        {

            Console.Write("Введите радиус круга: ");

            var input = Console.ReadLine();

            var radius = ShapeValidator.GetValidValue(input);

            return radius;
        }

        /// <summary>
        /// Ввод длин сторон треугольника из консоли
        /// </summary>
        /// <returns>Массив длин сторон треугольника</returns>
        public static double[] InputTriangleSides()
        {
            var sides = new double[3];

            for (int i = 0; i < 3; i++)
            {

                Console.Write($"Введите длину стороны {i + 1} треугольника: ");

                var input = Console.ReadLine();

                sides[i] = ShapeValidator.GetValidValue(input);

            }

            return sides;
        }

        /// <summary>
        /// Выбор значения перечисленых в консоли
        /// </summary>
        /// <typeparam name="TEnum">Тип перечисления</typeparam>
        /// <returns>Выбранное значение</returns>
        public static TEnum InputFromConsole<TEnum>() where TEnum : struct, Enum
        {
            OutputVariants<TEnum>();

            var variant = Input<TEnum>();

            EnumIsDefined(variant);

            return variant;
        }

        /// <summary>
        /// Проверяет является ли значение перечисления определенным
        /// </summary>
        /// <typeparam name="TEnum">Тип перечисления</typeparam>
        /// <param name="enumValue">Значение перечисления</param>
        private static void EnumIsDefined<TEnum>(TEnum enumValue) where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), enumValue))
                throw new ArgumentException("Некорректный ввод. Пожалуйста, выберите существующий номер типа.");
        }

        /// <summary>
        /// Выводит варианты в консоль
        /// </summary>
        /// <typeparam name="TEnum">Тип перечисления</typeparam>
        private static void OutputVariants<TEnum>() where TEnum : struct, Enum
        {
            Console.WriteLine("Выберите один из вариантов:");

            foreach (TEnum operationType in Enum.GetValues(typeof(TEnum)))
            {
                Console.WriteLine($"{Convert.ToInt32(operationType)}. {operationType}");
            }
        }

        /// <summary>
        /// Ввод значения из консоли
        /// </summary>
        /// <typeparam name="TEnum">Тип перечисления</typeparam>
        /// <returns>Выбранное значение</returns>
        private static TEnum Input<TEnum>() where TEnum : struct, Enum
        {

            Enum.TryParse(Console.ReadLine(), out TEnum selectedValue);
            return selectedValue;
        }
    }
}

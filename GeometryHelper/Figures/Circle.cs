using GeometryHelper.Interface;

namespace GeometryHelper.Figures
{
    /// <summary>
    /// Представляет круг
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Circle с указанным радиусом
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Вычисляет площадь круга
        /// </summary>
        /// <returns>Площадь круга.</returns>
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
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
            var circle = obj as Circle;

            return circle.Radius == Radius;
        }

        /// <summary>
        /// Возвращает хэш-код для данного объекта
        /// </summary>
        /// <returns>Хэш-код.</returns>
        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }
    }
}

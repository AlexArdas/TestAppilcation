using GeometryHelper.Interface;

namespace GeometryHelper.Interfaces
{
    /// <summary>
    /// Представляет интерфейс для валидатора фигур
    /// </summary>
    public interface IShapeValidator
    {
        /// <summary>
        /// Проверяет, является ли указанная фигура допустимой
        /// </summary>
        /// <param name="shape">Фигура для проверки</param>
        /// <returns>true, если фигура допустима; в противном случае - false.</returns>
        bool IsValid(IShape shape);
    }
}

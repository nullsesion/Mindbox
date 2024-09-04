namespace Contracts
{
	/// <summary>
	/// Представляет из себя закрытый путь из точек
	/// </summary>
	public interface IFigurePolygon : IFigure
	{
		/// <summary>
		/// Содержит ли полигон прямой угол
		/// </summary>
		bool HasRightAngle();
	}
}

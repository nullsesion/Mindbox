using Contracts.Primitives;

namespace Contracts
{
	/// <summary>
	/// Представляет из себя закрытый путь из точек
	/// </summary>
	public interface IFigurePolygon : IFigure
	{
		public IPoint[] Points { get; }
		void SetPoints(IPoint[] points);
		/// <summary>
		/// Содержит ли полигон прямой угол
		/// </summary>
		bool HasRightAngle();
	}
}

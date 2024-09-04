using Contracts.Attributs;
using Contracts.Primitives;
using Contracts;

namespace FigurePlugin.Figures
{
	[ExportFigure("Circle")]
	[CountPoints(1)]
	public class Circle : IFigureRotation
	{
		public IPoint[] Points { get; set; }

		public bool TryGetArea(out double area)
		{
			area = Math.PI * Radius * Radius;
			return true;
		}

		public double Radius { get; set; }
	}
}

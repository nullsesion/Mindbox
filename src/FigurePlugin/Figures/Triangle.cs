using Contracts;
using Contracts.Attributes;
using Contracts.Primitives;

namespace FigurePlugin.Figures
{
	[ExportFigure("Triangle")]
	[CountPoints(3)]
	public class Triangle : IFigurePolygon
	{
		public void SetPoints(IPoint[] points) => Points = points;

		public IPoint[] Points { get; private set; }
		public bool TryGetArea(out double area)
		{
			area = -1;
			if (Points.Length != 3)
				return false;

			double x1 = Points[0].X;
			double y1 = Points[0].Y;
			double x2 = Points[1].X;
			double y2 = Points[1].Y;
			double x3 = Points[2].X;
			double y3 = Points[2].Y;

			area = Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2d;
			return true;
		}

		public bool HasRightAngle()
		{
			//A
			double x1 = Points[0].X;
			double y1 = Points[0].Y;

			//B
			double x2 = Points[1].X;
			double y2 = Points[1].Y;

			//C
			double x3 = Points[2].X;
			double y3 = Points[2].Y;

			double AB = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
			double BC = (x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3);
			double CA = (x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2);

			List<double> lines = new List<double>();
			lines.Add(AB);
			lines.Add(BC);
			lines.Add(CA);

			lines.Sort();

			return (lines[0] + lines[1] == lines[2]);
		}
	}
}

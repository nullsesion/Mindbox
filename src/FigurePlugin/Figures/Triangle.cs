using Contracts;
using Contracts.Attributs;
using Contracts.Primitives;

namespace FigurePlugin.Figures
{

	[ExportFigure("Triangle")]
	[CountPoints(3)]
	public class Triangle : IFigurePolygon
	{
		public IPoint[] Points { get; set; }
		public bool TryGetArea(out double area)
		{
			area = 0;

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
			/*
			Take Point1=( 2, 1 )
			Take Point2=( 5, 7 )

			Find the LINEAR EQUATION of the line that passes through the points (2,1) and (5,7). Your answer must be in the form of Ax + By + C = 0.

			Using the equation:
			(y1 – y2)x + (x2 – x1)y + (x1y2 – x2y1) = 0

			We’ll just plug numbers in:
			(1 – 7)x + (5 – 2)y + ( (2 x 7) – (5 x 1) ) = 0
			-6x + 3y + (14 – 5) = 0
			-6x + 3y + 9 = 0

			Factoring a -3 out:
			-3( 2x – y – 3 ) = 0

			Dividing both sides by -3:
			2x – y – 3 = 0

			And that’s the answer.

		 */
			throw new NotImplementedException();
		}
	}
}

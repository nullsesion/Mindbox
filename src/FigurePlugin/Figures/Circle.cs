using Contracts.Primitives;
using Contracts;
using Contracts.Attributes;

namespace FigurePlugin.Figures
{
	[ExportFigure("Circle")]
	[CountRadius(1)]
	public class Circle : IFigureRotation
	{
		public void SetRadii(IRadius[] radii)
		{
			Radii = radii;
		}
		public IRadius[] Radii { get; private set; }

		public bool TryGetArea(out double area)
		{
			area = -1;
			if (Radii.Length != 1)
				return false;

			area = Math.PI * Radii[0].Value * Radii[0].Value;
			return true;
		}
	}
}

using Contracts;
using MasterSystem.Primitives;

namespace MasterSystem.BuilderFigure
{
	public abstract class AbstractFigureBuilder
	{
		protected Point[] _points { get; set; }
		protected Radius[] _radii { get; set; }
		protected uint _countPoint { get; set; }
		protected uint _countRadii { get; set; }

		public IFigure Figure { get; set; }
		public IFigurePolygon FigurePolygon { get; set; }
		public IFigureRotation FigureRotation { get; set; }
		public void Create()
		{
			SetPoints();
			SetRadii();
			if (FigurePolygon != null)
			{
				Figure = FigurePolygon;
			}
			if (FigureRotation != null)
			{
				Figure = FigureRotation;
			}
		}
		public abstract void SetPoints();
		public abstract void SetRadii();
	}
}

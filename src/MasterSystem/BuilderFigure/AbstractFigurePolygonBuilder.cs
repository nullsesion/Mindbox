using Contracts;

namespace MasterSystem.BuilderFigure
{
	public abstract class AbstractFigurePolygonBuilder
	{
		public IFigurePolygon Figure { get; protected set; }
		public void Create()
		{
			SetPoints();
			SetRadii();
		}
		public abstract void SetPoints();
		public abstract void SetRadii();
	}
}

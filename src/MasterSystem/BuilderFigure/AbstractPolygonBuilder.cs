using Contracts;

namespace MasterSystem.BuilderFigure
{
	public abstract class AbstractPolygonBuilder
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

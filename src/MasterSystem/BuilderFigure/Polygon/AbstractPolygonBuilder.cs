using Contracts;
using Contracts.Primitives;

namespace MasterSystem.BuilderFigure.Polygon
{
	public abstract class AbstractPolygonBuilder
	{
		protected IPoint[] _points { get; set; }
		protected uint _countPoint { get; set; }
		public IFigurePolygon Figure { get; protected set; }
		public void Create()
		{
			SetPoints();
		}
		public abstract void SetPoints();
	}
}

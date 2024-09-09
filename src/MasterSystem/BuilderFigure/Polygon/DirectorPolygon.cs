using Contracts;

namespace MasterSystem.BuilderFigure.Polygon
{
	public class DirectorPolygon
	{
		public IFigurePolygon Create(AbstractPolygonBuilder polygonBuilder)
		{
			polygonBuilder.Create();
			return polygonBuilder.Figure;
		}
	}
}

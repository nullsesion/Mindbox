using Contracts;

namespace MasterSystem.BuilderFigure
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

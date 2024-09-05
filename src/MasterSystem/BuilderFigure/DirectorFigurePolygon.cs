using Contracts;

namespace MasterSystem.BuilderFigure
{
	public class DirectorFigurePolygon
	{
		public IFigurePolygon Create(AbstractFigurePolygonBuilder figurePolygonBuilder)
		{
			figurePolygonBuilder.Create();
			return figurePolygonBuilder.Figure;
		}
	}
}

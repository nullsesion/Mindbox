using Contracts;
using MasterSystem.BuilderFigure.Polygon;

namespace MasterSystem.BuilderFigure
{
	public class DirectorFigure
	{
		public IFigure Create(AbstractFigureBuilder figureBuilder)
		{
			figureBuilder.Create();
			return figureBuilder.Figure;
		}
	}
}

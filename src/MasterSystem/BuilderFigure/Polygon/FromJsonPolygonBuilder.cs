using Contracts;
using MasterSystem.Services.LoadPluginManager;
using Contracts.Primitives;
using MasterSystem.BuilderFigure.Model;

namespace MasterSystem.BuilderFigure.Polygon
{
	public class FromJsonPolygonBuilder : AbstractPolygonBuilder
	{
		private FigureJsonModel _data { get; set; }
		public FromJsonPolygonBuilder(FigureInfo figureInfo, FigureJsonModel data)
		{
			_data = data;
			_countPoint = figureInfo.CountPoints;
			if (typeof(IFigurePolygon).IsAssignableFrom(figureInfo.TypeFigure))
			{
				Figure = Activator.CreateInstance(figureInfo.TypeFigure) as IFigurePolygon;
			}
		}

		public override void SetPoints()
		{
			if (Figure != null && _countPoint == _data.Points.Count())
			{
				_points = new IPoint[_countPoint];
				Figure.SetPoints(_data.Points.ToArray());
			}
		}
	}
}

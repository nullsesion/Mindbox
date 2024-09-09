using Contracts;
using Contracts.Primitives;
using MasterSystem.BuilderFigure.Model;
using MasterSystem.Primitives;
using MasterSystem.Services.LoadPluginManager;

namespace MasterSystem.BuilderFigure
{
	public class FromJsonFigureBuilder: AbstractFigureBuilder
	{
		private FigureJsonModel _data { get; set; }
		public FromJsonFigureBuilder(FigureInfo figureInfo, FigureJsonModel data)
		{
			_data = data;
			_countRadii = figureInfo.CountRadius;
			_countPoint = figureInfo.CountPoints;

			_points = new Point[_countPoint];
			_radii = new Radius[_countRadii];

			if (typeof(IFigureRotation).IsAssignableFrom(figureInfo.TypeFigure))
			{
				FigureRotation = Activator.CreateInstance(figureInfo.TypeFigure) as IFigureRotation;
				//Figure = FigureRotation;
				return;
			}
			if (typeof(IFigurePolygon).IsAssignableFrom(figureInfo.TypeFigure))
			{
				FigurePolygon = Activator.CreateInstance(figureInfo.TypeFigure) as IFigurePolygon;
				//Figure = FigurePolygon;
			}
		}

		public override void SetPoints()
		{
			if (FigurePolygon != null && _countPoint == _data.Points.Count)
			{
				FigurePolygon.SetPoints(_data.Points.ToArray());
			}
		}

		public override void SetRadii()
		{
			if (FigureRotation != null && _countRadii == _data.Radii.Count)
			{
				FigureRotation.SetRadii(_data.Radii.ToArray());
			}
		}
	}
}

using Contracts;
using Contracts.Primitives;
using MasterSystem.Primitives;
using MasterSystem.Services.LoadPluginManager;

namespace MasterSystem.BuilderFigure
{
	public class RandomFigurePolygonFigurePolygonBuilder: AbstractFigurePolygonBuilder
	{
		private IPoint[] _points { get; set; }
		private IRadius[] _radii { get; set; }

		private uint _countPoint { get; set; }
		private uint _countRadii { get; set; }
		public RandomFigurePolygonFigurePolygonBuilder(Type type, FigureInfo figureInfo)
		{
			_countPoint = figureInfo.CountPoints;
			_countRadii = figureInfo.CountRadius;
			
			if (typeof(IFigurePolygon).IsAssignableFrom(type))
			{
				Figure = Activator.CreateInstance(type) as IFigurePolygon;
			}
		}

		public override void SetPoints()
		{
			if (Figure != null && _countPoint > 0)
			{
				_points = new IPoint[_countPoint];
				for (int i = 0; i < _countPoint; i++)
				{
					Random rnd = new Random();
					double x = rnd.Next(1, 2000) / 100d;
					double y = rnd.Next(1, 2000) / 100d;

					_points[i] = new Point()
					{ X = x, Y = y };
				}
				Figure.SetPoints(_points);
			}
		}
		public override void SetRadii()
		{
			/*
			if (Figure != null && _countRadii > 0)
			{
				_radii = new IRadius[_countRadii];
				for (int i = 0; i < _countRadii; i++)
				{
					Random rnd = new Random();
					double r = rnd.Next(1,2000)/100d;
					_radii[i] = new Radius();
				}
			}
			*/
		}
	}
}

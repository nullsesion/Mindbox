using Contracts;
using Contracts.Primitives;
using MasterSystem.Primitives;
using MasterSystem.Services.LoadPluginManager;
using System.Text.Json;
using MasterSystem.BuilderFigure.Model;

namespace MasterSystem.BuilderFigure.Polygon
{
	public class RandomPolygonBuilder : AbstractPolygonBuilder
	{
		private FigureInfo _figureInfo { get; set; }
		public RandomPolygonBuilder(FigureInfo figureInfo)
		{
			_countPoint = figureInfo.CountPoints;
			_figureInfo = figureInfo;
			if (typeof(IFigurePolygon).IsAssignableFrom(figureInfo.TypeFigure))
			{
				Figure = Activator.CreateInstance(figureInfo.TypeFigure) as IFigurePolygon;
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

				FigureJsonModel p = new FigureJsonModel();
				p.Name = _figureInfo.Name;
				p.Points = _points
					.ToList()
					.Select(c => new Point() { X = c.X, Y = c.Y })
					.ToList();
				
				string stringJson = JsonSerializer.Serialize(p);
				Console.WriteLine(JsonSerializer.Serialize(p));
				FigureJsonModel? t = JsonSerializer.Deserialize<FigureJsonModel>(stringJson);
				Console.WriteLine(JsonSerializer.Serialize(t));
				
			}
		}
	}
}

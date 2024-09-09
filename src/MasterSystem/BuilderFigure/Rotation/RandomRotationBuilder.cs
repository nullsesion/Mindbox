using Contracts.Primitives;
using MasterSystem.Primitives;
using Contracts;
using MasterSystem.Services.LoadPluginManager;
using System.Reflection;
using MasterSystem.BuilderFigure.Model;
using System.Text.Json;

namespace MasterSystem.BuilderFigure.Rotation
{
	public class RandomRotationBuilder : AbstractRotationBuilder
	{
		private FigureInfo _figureInfo { get; set; }
		public RandomRotationBuilder(FigureInfo figureInfo)
		{
			_countRadii = figureInfo.CountRadius;
			_figureInfo = figureInfo;
			if (typeof(IFigureRotation).IsAssignableFrom(figureInfo.TypeFigure))
			{
				Figure = Activator.CreateInstance(figureInfo.TypeFigure) as IFigureRotation;
			}
		}

		public override void SetRadii()
		{
			if (Figure != null && _countRadii > 0)
			{
				_radii = new IRadius[_countRadii];
				for (int i = 0; i < _countRadii; i++)
				{
					Random rnd = new Random();
					double r = rnd.Next(1,2000)/100d;
					_radii[i] = new Radius()
					{
						Value = r
					};
				}
				Figure.SetRadii(_radii);

				FigureJsonModel p = new FigureJsonModel();
				p.Name = _figureInfo.Name;
				p.Radii = _radii
					.ToList()
					.Select(c => new Radius()
					{
						Value = c.Value
					})
					.ToList();

				string stringJson = JsonSerializer.Serialize(p);
				Console.WriteLine(JsonSerializer.Serialize(p));
				FigureJsonModel? t = JsonSerializer.Deserialize<FigureJsonModel>(stringJson);
				Console.WriteLine(JsonSerializer.Serialize(t));

			}
		}
	}
}

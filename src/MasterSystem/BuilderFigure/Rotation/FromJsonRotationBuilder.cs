using Contracts;
using Contracts.Primitives;
using MasterSystem.BuilderFigure.Model;
using MasterSystem.BuilderFigure.Polygon;
using MasterSystem.Primitives;
using MasterSystem.Services.LoadPluginManager;

namespace MasterSystem.BuilderFigure.Rotation
{
	public class FromJsonRotationBuilder : AbstractRotationBuilder
	{
		private FigureJsonModel _data { get; set; }
		public FromJsonRotationBuilder(FigureInfo figureInfo, FigureJsonModel data)
		{
			_data = data;
			_countRadii = figureInfo.CountRadius;
			if (typeof(IFigureRotation).IsAssignableFrom(figureInfo.TypeFigure))
			{
				Figure = Activator.CreateInstance(figureInfo.TypeFigure) as IFigureRotation;
			}
		}

		public override void SetRadii()
		{
			if (Figure != null && _countRadii == _data.Radii.Count)
			{
				Figure.SetRadii(_data.Radii.ToArray());
			}
		}
	}
}

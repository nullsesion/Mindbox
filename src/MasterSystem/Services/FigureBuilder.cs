using Contracts.Primitives;
using Contracts;
using MasterSystem.Services.LoadPluginManager;

namespace MasterSystem.Services
{
	public class FigureBuilder
	{
		private readonly DisplayHelper _displayHelper;
		public FigureBuilder(DisplayHelper displayHelper)
		{
			_displayHelper = displayHelper;
		}

		public IFigure Create(FigureInfo figureInfo)
		{
			IPoint[] points = new IPoint[] { };
			if (figureInfo.CountPoints > 0)
			{
				points = new IPoint[figureInfo.CountPoints];
				for (int i = 0; i < figureInfo.CountPoints; i++)
				{
					points[i] = _displayHelper.AddPoint(figureInfo.Type);
				}
			}

			if (figureInfo.HasRadius)
			{
				IFigureRotation? figureRotation = Activator.CreateInstance(figureInfo.Type) as IFigureRotation;
				figureRotation.Points = points;
				figureRotation.Radius = _displayHelper.AddRadius("Enter Radius figure:");
				return figureRotation;
			}

			IFigurePolygon? figurePolygon = Activator.CreateInstance(figureInfo.Type) as IFigurePolygon;
			figurePolygon.Points = points;
			return figurePolygon;
		}
	}
}

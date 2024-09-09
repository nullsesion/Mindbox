using MasterSystem.Primitives;

namespace MasterSystem.BuilderFigure.Model
{
	public class FigureJsonModel
	{
		public string Name { get; set; }
		public List<Point> Points { get; set; }
		public List<Radius> Radii { get; set; }
	}
}

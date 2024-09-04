namespace MasterSystem.Services
{
	public class GeneratorPrimitives
	{
		private List<string> _points { get; set; }
		public GeneratorPrimitives()
		{
			_points = new List<string>();
		}

		public (double X, double Y) GenerationPoint()
		{
			Random rnd = new Random();
			double x, y;
			do
			{
				x = (double)rnd.Next(1, 20000) / 100;
				y = (double)rnd.Next(1, 20000) / 100;
			} while (_points.Contains($"{x},{y}"));

			_points.Add($"{x},{y}");
			return ((double)x, (double)y);
		}
		public double GenerationRadius()
		{
			Random rnd = new Random();
			int radius = rnd.Next(1, 100);
			return radius;
		}

		public void ResetHistoryPoints()
		{
			_points = new List<string>();
		}
	}
}

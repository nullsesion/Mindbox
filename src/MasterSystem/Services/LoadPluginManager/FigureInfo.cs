using Contracts.Primitives;

namespace MasterSystem.Services.LoadPluginManager
{
	public class FigureInfo
	{
		public string Name { get; set; }

		/// <summary>
		/// Количество радиусов необходимых для создания
		/// </summary>
		public uint CountRadius { get; set; }
		/// <summary>
		/// Количество точек необходимых для создания
		/// </summary>
		public uint CountPoints { get; set; }
		public IPoint[] Points { get; set; }
		public IRadius[] Radii { get; set; }
	}
}

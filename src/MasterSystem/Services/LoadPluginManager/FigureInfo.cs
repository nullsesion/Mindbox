namespace MasterSystem.Services.LoadPluginManager
{
	public class FigureInfo
	{
		public string Name { get; set; }
		public Type Type { get; set; }
		public bool HasRadius { get; set; }
		public uint CountPoints { get; set; }
		public bool HasRightAngle { get; set; }
	}
}

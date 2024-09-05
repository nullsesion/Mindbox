namespace Contracts.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class CountPointsAttribute : Attribute
	{
		public uint CountPoints { get; set; }
		public CountPointsAttribute(uint countPoints) => CountPoints = countPoints;
	}
}

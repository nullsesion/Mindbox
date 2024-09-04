namespace Contracts.Attributs
{
	[AttributeUsage(AttributeTargets.Class)]
	public class CountPointsAttribute : Attribute
	{
		public uint CountPoints { get; set; }
		public CountPointsAttribute(uint countPoints) => this.CountPoints = countPoints;
	}
}

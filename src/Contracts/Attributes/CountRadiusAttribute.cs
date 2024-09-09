namespace Contracts.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class CountRadiusAttribute: Attribute
	{
		public uint CountRadius { get; set; }
		public CountRadiusAttribute(uint countRadius) => CountRadius = countRadius;
	}
}

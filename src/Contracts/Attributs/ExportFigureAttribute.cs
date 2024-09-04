namespace Contracts.Attributs
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ExportFigureAttribute : Attribute
	{
		public readonly string Name;
		public ExportFigureAttribute(string name) => Name = name;
	}
}

namespace Contracts.Primitives;

/// <summary>
/// Ax + By + C = 0
/// </summary>
public interface ILine
{
	double A { get; set; }
	double B { get; set; }
	double C { get; set; }
}
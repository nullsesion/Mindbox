using Contracts.Primitives;

namespace Contracts;

public interface IFigure
{
	IPoint[] Points { get; set; }
	bool TryGetArea(out double area);
}
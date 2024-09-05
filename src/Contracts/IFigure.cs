using Contracts.Primitives;

namespace Contracts;

public interface IFigure
{
	bool TryGetArea(out double area);
}
using Contracts.Primitives;

namespace Contracts;

public interface IFigureRotation : IFigure
{
	public IRadius[] Radii { get; }
	void SetRadii(IRadius[] radii);
}
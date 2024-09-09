using Contracts;
using Contracts.Primitives;

namespace MasterSystem.BuilderFigure.Rotation
{
	public abstract class AbstractRotationBuilder
	{
		protected uint _countRadii { get; set; }
		protected IRadius[] _radii { get; set; }
		public IFigureRotation Figure { get; protected set; }
		public void Create()
		{
			SetRadii();
		}
		public abstract void SetRadii();
	}
}

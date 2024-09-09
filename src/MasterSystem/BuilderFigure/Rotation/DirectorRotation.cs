using Contracts;
using MasterSystem.BuilderFigure.Polygon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSystem.BuilderFigure.Rotation
{
	public class DirectorRotation
	{
		public IFigureRotation Create(AbstractRotationBuilder rotationBuilder)
		{
			rotationBuilder.Create();
			return rotationBuilder.Figure;
		}
	}
}

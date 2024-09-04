using Contracts.Primitives;
using FigurePlugin.Figures;
using Moq;

namespace FigurePlugin.Tests
{
	[TestClass]
	public class CircleTest
	{
		[TestMethod]
		public void Try_GetArea__Pnt_0_0_R1__double_PI_Returned()
		{
			Mock<IPoint> center = new Mock<IPoint>();
			center.Setup(x => x.X).Returns(0d);
			center.Setup(x => x.Y).Returns(0d);
			
			Circle circle = new Circle();
			circle.Points = new IPoint[] { center.Object };
			circle.Radius = 1d;

			if (circle.TryGetArea(out double area))
			{
				Assert.AreEqual(Math.PI, area);
			}
			else
			{
				Assert.Fail("an error occurred calc area");
			}
		}
	}
}

using Contracts.Primitives;
using FigurePlugin.Figures;
using Moq;

namespace FigurePlugin.Tests
{
	[TestClass]
	public class TriangleTest
	{
		[TestMethod]
		public void Try_GetArea__Pnt_0_0_Pnt_0_3_Pnt_5_0__double_6_Returned()
		{
			Mock<IPoint> point1 = new Mock<IPoint>();
			point1.Setup(x => x.X).Returns(0d);
			point1.Setup(x => x.Y).Returns(0d);

			Mock<IPoint> point2 = new Mock<IPoint>();
			point2.Setup(x => x.X).Returns(0d);
			point2.Setup(x => x.Y).Returns(3d);

			Mock<IPoint> point3 = new Mock<IPoint>();
			point3.Setup(x => x.X).Returns(4d);
			point3.Setup(x => x.Y).Returns(3d);

			IPoint[] points = new IPoint[]
			{
				point1.Object,
				point2.Object,
				point3.Object,
			};

			Triangle triangle = new Triangle();
			triangle.SetPoints(points);
			if (triangle.TryGetArea(out double area))
			{
				Assert.AreEqual(6, area);
			}
			else
			{
				Assert.Fail("an error occurred calc area");
			}
		}
	}
}

using Contracts.Primitives;
using FigurePlugin.Figures;
using Moq;

namespace FigurePlugin.Tests
{
	[TestClass]
	public class CircleTest
	{
		[TestMethod]
		public void Try_GetArea__R_1__PI_Returned()
		{
			Mock<IRadius> radius = new Mock<IRadius>();
			radius.Setup(x => x.Value).Returns(1d);

			Circle circle = new Circle();
			circle.SetRadii(new IRadius[]{ radius.Object });
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

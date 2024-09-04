using System.Reflection;
using Contracts;
using Contracts.Attributs;

namespace MasterSystem.Services.LoadPluginManager
{
	public class LoadPluginManager
	{
		public Assembly LoadPlugin(string dirPlugin)
		{
			string root = Path.GetFullPath(Path.Combine(
				Path.GetDirectoryName(
					Path.GetDirectoryName(
						Path.GetDirectoryName(
							Path.GetDirectoryName(
								Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));

			string pluginLocation = Path.GetFullPath(Path.Combine(root, dirPlugin.Replace('\\', Path.DirectorySeparatorChar)));
			PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
			return loadContext.LoadFromAssemblyName(AssemblyName.GetAssemblyName(pluginLocation));
		}

		public static IEnumerable<FigureInfo> FindAllTypeFigursFromAssembly(Assembly assembly)
		{
			var types = assembly.ExportedTypes
				.Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(ExportFigureAttribute)))
				.ToArray();
			;

			List<FigureInfo> figures = new List<FigureInfo>();
			foreach (Type type in types)
			{
				if (typeof(IFigure).IsAssignableFrom(type))
				{
					ExportFigureAttribute exportFigureAttribute =
						(ExportFigureAttribute)Attribute.GetCustomAttribute(type, typeof(ExportFigureAttribute));

					CountPointsAttribute countPointsAttribute =
						(CountPointsAttribute)Attribute.GetCustomAttribute(type, typeof(CountPointsAttribute));


					figures.Add(new FigureInfo()
					{
						Name = exportFigureAttribute.Name,
						Type = type,
						CountPoints = countPointsAttribute?.CountPoints ?? 0, //сколько точек нужно для создания фигуры
						HasRadius = typeof(IFigureRotation)
							.IsAssignableFrom(type),                          //есть ли возможность добавить радиус
						HasRightAngle =
							((countPointsAttribute?.CountPoints ?? 1) > 2)   //есть ли возможность найти прямой угол
					});
				}
			}

			return figures.ToArray();
		}
	}
}

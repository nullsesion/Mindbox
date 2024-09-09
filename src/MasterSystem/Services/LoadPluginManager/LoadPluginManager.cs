using System.Reflection;
using Contracts;
using Contracts.Attributes;

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

		public static List<FigureInfo> FindAllTypeFigursFromAssembly(Assembly assembly)
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
					figures.Add(new FigureInfo()
					{
						Name = GetNameByType(type),
						TypeFigure = type,
						CountPoints = GetCountPointsByType(type), //сколько точек нужно для создания фигуры
						CountRadius = GetCountRadiusByType(type), //сколько радиусов нужно для создания фигуры
					});
				}
			}
			return figures;
		}

		public static uint GetCountPointsByType(Type type)
		{
			CountPointsAttribute countPointsAttribute =
				(CountPointsAttribute)Attribute.GetCustomAttribute(type, typeof(CountPointsAttribute));
			return countPointsAttribute?.CountPoints ?? 0;
		}

		public static uint GetCountRadiusByType(Type type)
		{
			CountRadiusAttribute countRadiusAttribute =
				(CountRadiusAttribute)Attribute.GetCustomAttribute(type, typeof(CountRadiusAttribute));
			return countRadiusAttribute?.CountRadius ?? 0;
		}

		public static string GetNameByType(Type type)
		{
			ExportFigureAttribute exportFigureAttribute =
				(ExportFigureAttribute)Attribute.GetCustomAttribute(type, typeof(ExportFigureAttribute));
			return exportFigureAttribute?.Name ?? "";
		}
	}
}

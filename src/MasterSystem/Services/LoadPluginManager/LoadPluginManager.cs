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

		public static Dictionary<Type, FigureInfo> FindAllTypeFigursFromAssembly(Assembly assembly)
		{
			var types = assembly.ExportedTypes
				.Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(ExportFigureAttribute)))
				.ToArray();
			;

			Dictionary<Type, FigureInfo> figures = new Dictionary<Type, FigureInfo>();
			foreach (Type type in types)
			{
				if (typeof(IFigure).IsAssignableFrom(type))
				{
					ExportFigureAttribute exportFigureAttribute =
						(ExportFigureAttribute)Attribute.GetCustomAttribute(type, typeof(ExportFigureAttribute));

					CountPointsAttribute countPointsAttribute =
						(CountPointsAttribute)Attribute.GetCustomAttribute(type, typeof(CountPointsAttribute));

					CountRadiusAttribute countRadiusAttribute =
						(CountRadiusAttribute)Attribute.GetCustomAttribute(type, typeof(CountRadiusAttribute));

					var value = new FigureInfo()
					{
						Name = exportFigureAttribute.Name,
						CountPoints = countPointsAttribute?.CountPoints ?? 0, //сколько точек нужно для создания фигуры
						CountRadius =
							countRadiusAttribute?.CountRadius ?? 0, //сколько радиусов нужно для создания фигуры
					};
					figures[type] = value;
				}
			}
			return figures;
		}
	}
}

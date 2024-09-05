using MasterSystem.Services.LoadPluginManager;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;
using Contracts;
using Contracts.Primitives;
using MasterSystem.BuilderFigure;

internal class Program
{
	static void Main(string[] args)
	{
		ServiceProvider serviceProvider = CreateServiceProvider();
		LoadPluginManager loader = serviceProvider.GetRequiredService<LoadPluginManager>();

		Assembly assamblyPlugin = loader.LoadPlugin("""FigurePlugin\bin\Debug\net8.0\FigurePlugin.dll""");
		var aviableFigures = LoadPluginManager.FindAllTypeFigursFromAssembly(assamblyPlugin);


		KeyValuePair<Type, FigureInfo> figure = aviableFigures.First(x => x.Value.Name == "Triangle");

		DirectorFigurePolygon director = new DirectorFigurePolygon();
		RandomFigurePolygonFigurePolygonBuilder randomFigurePolygonFigurePolygonBuilder =
			new RandomFigurePolygonFigurePolygonBuilder(figure.Key, figure.Value);

		IFigurePolygon figureBuild = director.Create(randomFigurePolygonFigurePolygonBuilder);
		Console.WriteLine(JsonSerializer.Serialize(figureBuild));
		
	}
	static ServiceProvider CreateServiceProvider()
	{
		var collection = new ServiceCollection();
		collection.AddSingleton<LoadPluginManager>();


		return collection.BuildServiceProvider();
	}
}
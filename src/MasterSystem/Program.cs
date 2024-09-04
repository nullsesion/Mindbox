using Contracts;
using MasterSystem.Services.LoadPluginManager;
using MasterSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal class Program
{
	static void Main(string[] args)
	{
		ServiceProvider serviceProvider = CreateServiceProvider();
		LoadPluginManager loader = serviceProvider.GetRequiredService<LoadPluginManager>();
		DisplayHelper displayHelper = serviceProvider.GetRequiredService<DisplayHelper>();
		FigureBuilder figureBuilder = serviceProvider.GetRequiredService<FigureBuilder>();

		Assembly assamblyPlugin = loader.LoadPlugin("""FigurePlugin\bin\Debug\net8.0\FigurePlugin.dll""");
		IEnumerable<FigureInfo> aviableFigures = LoadPluginManager.FindAllTypeFigursFromAssembly(assamblyPlugin);

		string selectedFigure = displayHelper.SelectionPrompt(
			"Select create figure from plugin?",
			"Move up and down to reveal more figure",
			aviableFigures.Select(x => x.Name).ToArray());

		FigureInfo figureInfo = aviableFigures.First(x => x.Name == selectedFigure);

		IFigure? figure = figureBuilder.Create(figureInfo);
		if (figure != null && figure.TryGetArea(out double area))
		{
			displayHelper.WriteLine($"Area: {area}");
		}
		else
		{
			displayHelper.WriteLine($"Error get area");
		}
	}
	static ServiceProvider CreateServiceProvider()
	{
		var collection = new ServiceCollection();
		collection.AddSingleton<LoadPluginManager>();
		collection.AddSingleton<GeneratorPrimitives>();
		collection.AddSingleton<FigureBuilder>();
		collection.AddSingleton<DisplayHelper>();

		return collection.BuildServiceProvider();
	}
}
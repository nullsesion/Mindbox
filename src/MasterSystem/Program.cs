using MasterSystem.Services.LoadPluginManager;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;
using Contracts;
using MasterSystem.BuilderFigure.Polygon;
using MasterSystem.BuilderFigure.Rotation;
using MasterSystem.BuilderFigure;
using MasterSystem.BuilderFigure.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MasterSystem.Services.IO;
using System.Collections.Generic;
using Spectre.Console;


internal class Program
{
	static void Main(string[] args)
	{
		string dllFileName = "FigurePlugin.dll";
		//загружаем сервисы из DI
		ServiceProvider serviceProvider = CreateServiceProvider();
		LoadPluginManager loader = serviceProvider.GetRequiredService<LoadPluginManager>();
		FiguresLoader figuresLoader = serviceProvider.GetRequiredService<FiguresLoader>();

		//Загружаем типы фигур из внешней библиотеки 
		Assembly assamblyPlugin = loader.LoadPlugin("""FigurePlugin\bin\Debug\net8.0\""" + dllFileName);
		List<FigureInfo> aviableFigures = LoadPluginManager.FindAllTypeFigursFromAssembly(assamblyPlugin);

		//загружаем конфиг
		IConfigurationBuilder builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false);

		IConfiguration config = builder.Build();
		//получаем имя файла с фигурами в json
		IConfigurationSection configFile = config.GetSection(dllFileName.Split('.').First());

		/*
		if (figuresLoader.GetListJsonFiguresFromFile(configFile.Value, out List<FigureJsonModel>? listJson))
		{
			foreach (FigureJsonModel item in listJson)
			{
				FigureInfo figureInfo = aviableFigures.First(x => x.Name == item.Name);
				IFigure figure = null;
				if (typeof(IFigurePolygon).IsAssignableFrom(figureInfo.TypeFigure)
				    || typeof(IFigureRotation).IsAssignableFrom(figureInfo.TypeFigure))
				{
					DirectorFigure directorFigure = new DirectorFigure();
					var figureBuilder =
						new FromJsonFigureBuilder(figureInfo, item);

					figure = directorFigure.Create(figureBuilder);
					if (figure.TryGetArea(out double area))
					{
						Console.WriteLine(area);
					}

					
				}
			}
		}
		*/

		//создаем фигуры билдером
		if (figuresLoader.GetListJsonFiguresFromFile(configFile.Value, out List<FigureJsonModel>? listJson))
		{
			IEnumerable<FigureOutput> figures = listJson.Select(f =>
			{
				FigureInfo figureInfo = aviableFigures.First(x => x.Name == f.Name);
				IFigure figure = null;

				if (typeof(IFigurePolygon).IsAssignableFrom(figureInfo.TypeFigure)
				    || typeof(IFigureRotation).IsAssignableFrom(figureInfo.TypeFigure))
				{
					DirectorFigure directorFigure = new DirectorFigure();
					var figureBuilder =
						new FromJsonFigureBuilder(figureInfo, f);

					figure = directorFigure.Create(figureBuilder);

					string areaData = "";
					if (figure.TryGetArea(out double area))
						areaData = area.ToString();
					else
						areaData = "Not Found";

					return new FigureOutput()
					{
						Name = f.Name,
						TypeFigure = figureInfo.TypeFigure.ToString(),
						Area = areaData,
						HasRightAngle = (figure as IFigurePolygon)?.HasRightAngle().ToString() ?? "not support",
					};
				}
				return null;
			}).Where(x => x != null);

			//отображаем таблицу с данными по фигурам.
			ShowData(figures);
		}
	}


	static void ShowData(IEnumerable<FigureOutput> figures)
	{
		var table = new Table();

		table.AddColumn("Name");
		table.AddColumn("Type");
		table.AddColumn("Area");
		table.AddColumn("HasRightAngle");

		foreach (var item in figures)
		{
			table.AddRow(item.Name,item.TypeFigure, item.Area, item.HasRightAngle);
		}
		AnsiConsole.Write(table);
	}
	
	static ServiceProvider CreateServiceProvider()
	{
		var collection = new ServiceCollection();
		collection.AddSingleton<LoadPluginManager>();
		collection.AddSingleton<FiguresLoader>();

		return collection.BuildServiceProvider();
	}
}
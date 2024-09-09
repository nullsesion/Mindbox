using MasterSystem.BuilderFigure.Model;
using System.Text.Json;

namespace MasterSystem.Services.IO
{
	public class FiguresLoader
	{
		public bool GetListJsonFiguresFromFile(string fileName, out List<FigureJsonModel>? listJson)
		{
			listJson = null;
			if (File.Exists(fileName))
			{
				string json = File.ReadAllText(fileName);
				listJson = JsonSerializer.Deserialize<List<FigureJsonModel>>(json);
				if (listJson != null)
					return true;
			}
			return false;
		}
	}
}

using Contracts.Primitives;
using MasterSystem.Primitives;
using Spectre.Console;

namespace MasterSystem.Services
{
	public class DisplayHelper
	{
		public void ShowHead(string message)
		{
			var startLoad = new Rule($"[green]{message}[/]");
			startLoad.Justification = Justify.Left;
			AnsiConsole.Write(startLoad);
		}
		public void Ok(string message = "")
		{
			AnsiConsole.MarkupLine($"{message} [green]Ok[/] ");
		}

		public void Write(string message = "")
		{
			AnsiConsole.Write(message);
		}

		public void WriteLine(string message = "")
		{
			AnsiConsole.WriteLine(message);
		}

		public void Fail(string message = "")
		{
			AnsiConsole.MarkupLine($"{message} [red]Fail[/] ");
		}
		public bool Confirm(string message, bool def)
		{
			return AnsiConsole.Confirm(message, def);
		}
		public string SelectionPrompt(string message, string selectionText, string[] strings)
		{
			return AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title($"[green]{message}[/]?")
					.PageSize(strings.Count() + 1)
					.MoreChoicesText($"[grey]({selectionText})[/]")
					.AddChoices(strings));
		}
		//_point
		//public IPoint AddPoint(Type point)
		public IPoint AddPoint(Type point)
		{
			string[] listSelect = new[]
			{
				"Manual",
				"Generate"
			};
			var userSelect = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title($"[green]Select generate or input point[/]?")
					.PageSize(3)
					//.MoreChoicesText($"[grey]({selectionText})[/]")
					.AddChoices(listSelect));
			if (userSelect == "Manual")
			{
				return EnterPoint(point);
			}
			//Generate
			return GeneratePoint(point);
		}

		public double AddRadius(string prompt)
		{
			string[] listSelect = new[]
			{
				"Manual",
				"Generate"
			};
			var userSelect = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
					.Title($"[green]Select generate or input radius[/]?")
					.PageSize(3)
					//.MoreChoicesText($"[grey]({selectionText})[/]")
					.AddChoices(listSelect));
			if (userSelect == "Manual")
			{
				return AnsiConsole.Ask<double>(prompt);
			}
			//Generate
			Random random = new Random();
			return random.NextDouble() * (2000 - 1) + 1; ;
		}

		private IPoint EnterPoint(Type point)
		{
			Activator.CreateInstance(point);
			double x = AnsiConsole.Ask<double>("Enter: X");
			double y = AnsiConsole.Ask<double>("Enter: Y");
			IPoint p = new Point();
			p.X = x; p.Y = y;
			return p;
		}
		private IPoint GeneratePoint(Type point)
		{
			Random random = new Random();
			double x = random.NextDouble() * (2000 - 1) + 1;
			double y = random.NextDouble() * (2000 - 1) + 1;
			IPoint p = new Point();
			p.X = x; p.Y = y;
			return p;
		}
	}
}

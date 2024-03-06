using TUI.Structs;
using static System.Net.Mime.MediaTypeNames;
using TUI.Builder.TUIParts;

namespace TUI
{
    public static class TUIErrorMessage
	{
		static TUIObjectBuilder Builder = new(new ObjectBuilderDefaults(ConsoleColor.Black, ConsoleColor.DarkRed));
		static bool b;
		public static void Show(string message, string? title=null)
		{
			TUIManager.UpdateBuffers();
			int width = TUIManager.BufferWidth / 2;
			int height = TUIManager.BufferHeight / 2;

            int LineLength = TUILabelPart.PredictLineLenght(message, TUIManager.BufferWidth - 10);
            int LabelHeight = TUILabelPart.PredictHeight(message, TUIManager.BufferWidth - 10);

            TUIObject @object;
			Builder.Reset();
			@object = Builder
				.AddColorOverlay("LOU", 1, 6, ConsoleColor.Red, new(-LineLength / 2 - 3, -3))
				.AddColorOverlay("LOD", 1, 1, ConsoleColor.Red, new(-LineLength / 2 - 3, 4))
				.AddColorOverlay("ROU", 1, 6, ConsoleColor.Red, new(LineLength / 2 + 5 + (LineLength % 2 == 0 ? -1 : 0), -3))
				.AddColorOverlay("ROD", 1, 1, ConsoleColor.Red, new(LineLength / 2 + 5+(LineLength % 2  ==0 ? -1 : 0), 4))
				.Build(new(width, height +1));


			TUIMessageBox.Show(message, title, ConsoleColor.DarkRed, ConsoleColor.Black,foo);

			@object.Clear();

			void foo() {

				TUIManager.UpdateBuffers();
				if (b)
					@object.Draw();
				else
					@object.Clear();

					
					Thread.Sleep(250);
				b = !b;
			}
		}
	}
}

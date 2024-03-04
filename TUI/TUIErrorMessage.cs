using TUI.Structs;

namespace TUI
{
	public static class TUIErrorMessage
	{
		static TUIObjectBuilder Builder = new(new ObjectBuilderDefaults(ConsoleColor.Black, ConsoleColor.DarkRed));
		static bool b;
		public static void Show(string message, string? title=null)
		{

			int width = TUIManager.BufferWidth / 2;
			int height = TUIManager.BufferHeight / 2;

			TUIObject @object;
			Builder.Reset();
			@object = Builder
				.AddColorOverlay("LOU", 1, 6, ConsoleColor.Red, new(-message.Length / 2 - 3, -3))
				.AddColorOverlay("LOD", 1, 1, ConsoleColor.Red, new(-message.Length / 2 - 3, 4))
				.AddColorOverlay("ROU", 1, 6, ConsoleColor.Red, new(message.Length / 2 + 4, -3))
				.AddColorOverlay("ROD", 1, 1, ConsoleColor.Red, new(message.Length / 2 + 4, 4))
				.Build(new(width, height));


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

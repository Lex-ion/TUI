using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
	public static class TUIWarningMessage
	{
		static TUIObjectBuilder Builder = new(new ObjectBuilderDefaults(ConsoleColor.Black, ConsoleColor.Yellow));
		static bool b;
		public static void Show(string message, string? title = null)
		{
			
			int width = TUIManager.BufferWidth / 2;
			int height = TUIManager.BufferHeight / 2;
			
			TUIObject @object;
			Builder.Reset();
			@object = Builder
				.AddColorOverlay("OU", message.Length+2, 1, ConsoleColor.DarkYellow, new(-message.Length / 2 , -5))
				.AddColorOverlay("ROD", message.Length + 2, 1, ConsoleColor.DarkYellow, new(-message.Length / 2 , 6))
				.Build(new(width, height));
			

			TUIMessageBox.Show(message, title, ConsoleColor.Yellow, ConsoleColor.Black,foo);

			@object.Clear();

		void foo()
		{
		
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

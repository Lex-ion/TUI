using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;
using static System.Net.Mime.MediaTypeNames;
using TUI.TUIParts;

namespace TUI
{
	public static class TUIWarningMessage
	{
		static TUIObjectBuilder Builder = new(new ObjectBuilderDefaults(ConsoleColor.Black, ConsoleColor.Yellow));
		static bool b;
		public static void Show(string message, string? title = null)
		{
			TUIManager.UpdateBuffers();

			int width = TUIManager.BufferWidth / 2;
			int height = TUIManager.BufferHeight / 2;
			TUIObject @object;
			Builder.Reset();
			@object = Builder
				.AddColorOverlay("OU", message.Length+2, 1, ConsoleColor.DarkYellow, new(-TUILabelPart.PredictLineLenght(message, TUIManager.BufferWidth - 6) / 2 , -5- TUILabelPart.PredictHeight(message, TUIManager.BufferWidth - 10)/2 ))
				.AddColorOverlay("ROD", message.Length + 2, 1, ConsoleColor.DarkYellow, new(-TUILabelPart.PredictLineLenght(message, TUIManager.BufferWidth - 6) / 2 , 1+ TUILabelPart.PredictHeight(message, TUIManager.BufferWidth - 10)/2 + 4))
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

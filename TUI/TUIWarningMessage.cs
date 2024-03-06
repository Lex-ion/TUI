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


            int LineLength = TUILabelPart.PredictLineLenght(message, TUIManager.BufferWidth - 10);
            int LabelHeight = TUILabelPart.PredictHeight(message, TUIManager.BufferWidth - 10);

            TUIObject @object;
			Builder.Reset();
			@object = Builder
				.AddColorOverlay("OU", LineLength + 2, 1, ConsoleColor.DarkYellow, new(-LineLength / 2 , -5- LabelHeight/2 ))
				.AddColorOverlay("OD", LineLength + 2, 1, ConsoleColor.DarkYellow, new(-LineLength/ 2 ,  LabelHeight/2 + 6 +(LabelHeight / 2 > 0 ? -1 : 0)))
				.Build(new(width, height+1));
			

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

using TUI.TUIParts;
using static System.Net.Mime.MediaTypeNames;

namespace TUI
{
	public static class TUIMessageBox
	{
		static TUIObjectBuilder builder = new TUIObjectBuilder();

		public static void Show(string text, string? title=null,ConsoleColor? backColor=null,ConsoleColor? foreColor=null,Action? idleAction=null)
		{

			TUIManager.UpdateBuffers();
			foreColor ??= builder.Defaults.ForeGround;
			backColor ??= builder.Defaults.BackGround;

			builder.Defaults = new((ConsoleColor)foreColor, (ConsoleColor)backColor);

			bool focused = true;
			builder.Reset();
			int width = TUIManager.BufferWidth / 2;
			int height = TUIManager.BufferHeight / 2;
			TUIObject @object;

			int LineLength = TUILabelPart.PredictLineLenght(text, TUIManager.BufferWidth - 10);
			int LabelHeight = TUILabelPart.PredictHeight(text, TUIManager.BufferWidth - 10);

			builder
				.AddColorOverlay("O", LineLength + 3, LabelHeight + 6, (ConsoleColor)backColor, new(-LineLength / 2 - 1, -LabelHeight/2-2))
				.AddLabel("L0", text, new(-LineLength / 2 + 1, -LabelHeight / 2 ), TUIManager.BufferWidth -10)			
				.AddFrame("F", LineLength + 2, 5 + builder._Product.Parts["L0"].Height, new(-LineLength / 2 - 1,-LabelHeight/2-2))
				.AddButton("B","> OK <",Done,new(-2, LabelHeight / 2+( LabelHeight /2>0?2:3)));

			if (title != null)
				builder.AddLabel("L1", title, new(-LineLength/2+1,- LabelHeight / 2 - 2));

			@object = builder.Build(new(width, height));

			@object.TUIInteractable!.IsSelected = true;

			@object.Draw();

			while (focused)
			{
				if (idleAction != null)
				{
					if (Console.KeyAvailable)
						if (TUIManager.GetKey().Key == ConsoleKey.Enter)
							@object.TUIInteractable!.Interact();

					idleAction?.Invoke();
				}else
				{
					if (TUIManager.GetKey().Key == ConsoleKey.Enter)
						@object.TUIInteractable!.Interact();
				}
				
			}

			@object.Clear();

			void Done() => focused = false;			
		}
	}
}

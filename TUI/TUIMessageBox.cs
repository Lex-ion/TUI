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


			builder
				.AddColorOverlay("O", TUILabelPart.PredictLineLenght(text, TUIManager.BufferWidth - 6) + 3, 8, (ConsoleColor)backColor, new(-TUILabelPart.PredictLineLenght(text, TUIManager.BufferWidth - 6) / 2 - 1, -3))
				.AddLabel("L0", text, new(-TUILabelPart.PredictLineLenght(text, TUIManager.BufferWidth - 6) / 2 + 1, 0), TUIManager.BufferWidth - 6);
			TUILabelPart l = (TUILabelPart)builder._Product.Parts["L0"];
			builder
				.AddFrame("F", l.LineLenght + 2, 5 + builder._Product.Parts["L0"].Height, new(-TUILabelPart.PredictLineLenght(text, TUIManager.BufferWidth - 6) / 2 - 1, -3))
				.AddButton("B","> OK <",Done,new(-2,2+ builder._Product.Parts["L0"].Height));

			if (title != null)
				builder.AddLabel("L1", title, new(-text.Length/2, -3));

			@object = builder.Build(new(width,height));

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

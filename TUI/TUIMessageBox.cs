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
				.AddColorOverlay("O", text.Length + 3,8,(ConsoleColor)backColor, new(-text.Length / 2 - 1, -3))
				.AddFrame("F", text.Length + 2, 6, new(- text.Length / 2 - 1, - 3))
				.AddLabel("L0",text,new( -text.Length/2+1,0))
				.AddButton("B","> OK <",Done,new(-2,2));

			if (title != null)
				builder.AddLabel("L1", title, new(-text.Length/2, -3));

			@object = builder.Build(new(width,height));

			@object.TUIInteractable!.IsSelected = true;

			@object.Draw();

			while (focused)
			{
				if(Console.KeyAvailable)
				if(TUIManager.GetKey().Key ==ConsoleKey.Enter)
					@object.TUIInteractable!.Interact();
				idleAction?.Invoke();
			}

			@object.Clear();

			void Done() => focused = false;			
		}
	}
}

using TUI.Structs;

namespace TUI
{
	public static class TUIErrorMessage
	{
		static TUIObjectBuilder Builder = new(new ObjectBuilderDefaults(ConsoleColor.Black, ConsoleColor.DarkRed));
		public static void Show(string message, string? title)
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


			CancellationTokenSource tokenSource = new CancellationTokenSource();

			ThreadPool.QueueUserWorkItem(new WaitCallback(foo), tokenSource.Token);

			Thread thread = new Thread(foo);
			thread.Start();

			TUIMessageBox.Show(message, title, ConsoleColor.DarkRed, ConsoleColor.Black);

			tokenSource.Cancel();

			@object.Clear();

			Thread.Sleep(250);

			void foo(object? obj) {
				if(obj is null)
					return;
				CancellationToken token = (CancellationToken)obj;

				Thread.Sleep(50);
			while (true)
				{
					if(token.IsCancellationRequested) 
						break;

					TUIManager.UpdateBuffers();
					@object.Draw();
						Thread.Sleep(250);
						@object.Clear();
						Thread.Sleep(250);
				}
				@object.Clear();
			}
		}
	}
}

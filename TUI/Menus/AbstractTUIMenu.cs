using System.Drawing;
using TUI.Defaults;
using TUI.Menus.PopUps;
using TUI.Structs;
using TUI.TUIParts;
using TUI.TUIParts.Builder;

namespace TUI.Menus
{
	public abstract class AbstractTUIMenu : ITUIMenu
	{
		public Dictionary<string, TUIObject> Objects { get; protected set; }

		public List<TUIObject> Interactables { get => Objects.Values.Where(o => o.IsInteractable).ToList(); }

		public Color BackGroundColor { get; protected set; }

		private TUIObject? selectedInteractable;


		private TUIObjectBuilder? objectBuilder;


		protected AbstractTUIMenu(TUIBuilderDefaults defaults, Color backGroundColor)
		{
			BackGroundColor = backGroundColor;

			Objects = new Dictionary<string, TUIObject>();

			objectBuilder = new(defaults, Objects);

			BuilderInstructions(objectBuilder);

			if (Interactables.Count > 0)
			{
				selectedInteractable = Interactables[0];
				selectedInteractable.TUIInteractable!.IsSelected= true;
			}
		}

		protected abstract void BuilderInstructions(TUIObjectBuilder builder);

		public void Draw()
		{
			TUIManager.UpdateBuffers();
			foreach (TUIObject obj in Objects.Values)
			{
				obj.Draw();
			}
		}

		public void Clear()
		{
			TUIObject bckgr = objectBuilder!.FabricateOverLay(TUIManager.BufferWidth, TUIManager.BufferHeight, BackGroundColor, new());

			TUIColorOverlay co = bckgr.Parts!.Values.OfType<TUIColorOverlay>().First();
			co.UseUnsafeDrawing = true;

			bckgr.Draw();
		}

		public void HandleInput(ConsoleKeyInfo info)
		{
			if (selectedInteractable is null) return;

			if (info.Key == ConsoleKey.Enter)
				selectedInteractable.TUIInteractable!.Interact();
			else if (info.Key == ConsoleKey.RightArrow)
			{
				selectedInteractable.TUIInteractable!.IsSelected = false;
				selectedInteractable = SearchObject(selectedInteractable, 0) ?? selectedInteractable;
				selectedInteractable.TUIInteractable!.IsSelected = true;
			}
			else if (info.Key == ConsoleKey.LeftArrow)
			{
				selectedInteractable.TUIInteractable!.IsSelected = false;
				selectedInteractable = SearchObject(selectedInteractable, SearchOptions.LEFT) ?? selectedInteractable;
				selectedInteractable.TUIInteractable!.IsSelected = true;
			}
			else if (info.Key == ConsoleKey.UpArrow)
			{
				selectedInteractable.TUIInteractable!.IsSelected = false;
				selectedInteractable = SearchObject(selectedInteractable, SearchOptions.UP) ?? selectedInteractable;
				selectedInteractable.TUIInteractable!.IsSelected = true;
			}
			else if (info.Key == ConsoleKey.DownArrow)
			{
				selectedInteractable.TUIInteractable!.IsSelected = false;
				selectedInteractable = SearchObject(selectedInteractable, SearchOptions.DOWN) ?? selectedInteractable;
				selectedInteractable.TUIInteractable!.IsSelected = true;
			}
			else if (info.Key == ConsoleKey.F1)
			{
				ShowHelp();
				TUIManager.RedrawCurrent();
			}
		}

		protected virtual void ShowHelp()
		{
			TUIMessageBox.Show("Nápověda zde není k dispozici.", "Nápověda", Color.DarkSlateBlue,Color.GhostWhite);			
		}

		TUIObject? SearchObject(TUIObject originObject, SearchOptions searchOptions)
		{
			Anchor originAnchor = originObject.Anchor;

			Anchor searchingAnchor = new(originAnchor.Left, originAnchor.Top);

			TUIObject? foundObj = null;

			while (IsInBounds(searchingAnchor) && foundObj is null)
			{
				switch (searchOptions)
				{
					case SearchOptions.RIGHT:
						for (int i = 0; i < Math.Abs(searchingAnchor.Left - originAnchor.Left) / 2; i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left && o.Anchor.Top == searchingAnchor.Top - i&&o.IsInteractable).FirstOrDefault();
						}

						for (int i = 0; i < Math.Abs(searchingAnchor.Left - originAnchor.Left) / 2; i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left && o.Anchor.Top == searchingAnchor.Top + i&&o.IsInteractable).FirstOrDefault();
						}
						searchingAnchor = new(searchingAnchor.Left + 1, searchingAnchor.Top);
						break;

					case SearchOptions.LEFT:
						for (int i = 0; i < Math.Abs(searchingAnchor.Left - originAnchor.Left) / 2; i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left && o.Anchor.Top == searchingAnchor.Top - i && o.IsInteractable).FirstOrDefault();
						}

						for (int i = 0; i < Math.Abs(searchingAnchor.Left - originAnchor.Left) / 2; i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left && o.Anchor.Top == searchingAnchor.Top + i&& o.IsInteractable).FirstOrDefault();
						}
						searchingAnchor = new(searchingAnchor.Left - 1, searchingAnchor.Top);
						break;

					case SearchOptions.DOWN:
						for (int i = 0; i < Math.Abs(searchingAnchor.Top - originAnchor.Top); i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left-i && o.Anchor.Top == searchingAnchor.Top && o.IsInteractable).FirstOrDefault();
						}

						for (int i = 0; i < Math.Abs(searchingAnchor.Top - originAnchor.Top); i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left+i && o.Anchor.Top == searchingAnchor.Top&& o.IsInteractable).FirstOrDefault();
						}
						searchingAnchor = new(searchingAnchor.Left, searchingAnchor.Top+1);
						break;

					case SearchOptions.UP:
						for (int i = 0; i < Math.Abs(searchingAnchor.Top - originAnchor.Top) ; i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left - i && o.Anchor.Top == searchingAnchor.Top).FirstOrDefault();
						}

						for (int i = 0; i < Math.Abs(searchingAnchor.Left - originAnchor.Left) ; i++)
						{
							foundObj ??= Objects.Values.Where(o => o.Anchor.Left == searchingAnchor.Left + i && o.Anchor.Top == searchingAnchor.Top).FirstOrDefault();
						}
						searchingAnchor = new(searchingAnchor.Left, searchingAnchor.Top -1);
						break;
				}
			}


			return foundObj;

			bool IsInBounds(Anchor lookingAnchor)
			{
				Anchor minimals = new(Objects.Values.Min(o => o.Anchor.Left), Objects.Values.Min(o => o.Anchor.Top));
				Anchor maximals = new(Objects.Values.Max(o => o.Anchor.Left), Objects.Values.Max(o => o.Anchor.Top));

				if (minimals.Left > lookingAnchor.Left || minimals.Top > lookingAnchor.Top)
					return false;
				if (maximals.Left < lookingAnchor.Left || maximals.Top < lookingAnchor.Top) return false;
				return true;
			}
		}
	}

	public enum SearchOptions
	{
		RIGHT = 0,
		LEFT = 1,
		UP = 2,
		DOWN = 3
	}
}

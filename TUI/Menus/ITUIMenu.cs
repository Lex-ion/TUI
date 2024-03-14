using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.TUIParts.Builder;

namespace TUI.Menus
{
    public interface ITUIMenu
	{
		Dictionary<string, TUIObject> Objects { get; }

		List<TUIObject> Interactables { get; }

		public void Draw();

		public void Clear();

		public void HandleInput(ConsoleKeyInfo info);


	}
}

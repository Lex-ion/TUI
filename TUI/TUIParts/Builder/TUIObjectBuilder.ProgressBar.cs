using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts.Builder
{
	public partial class TUIObjectBuilder
	{
		public TUIObjectBuilder AddProgressBar(string name, Anchor anchor, int width, int height, int value, int maximum, int minimum,char fillChar, char emptyChar , Color foreColor , Color backColor , bool isEnabled )
		{
			TUIProgressBarPart pb = new(name, anchor, width, height, value, maximum, minimum,fillChar,emptyChar, foreColor, backColor, isEnabled, TUIObjectPartType.PROGRESS_BAR);
			Product.AddPart(pb);

			return this;
		}

		public TUIObjectBuilder AddProgressBar(string name, Anchor anchor, int width, int height, int value, int maximum, int minimum, char fillChar, char emptyChar)
		{
			var defs = Defaults.DefaultProgressBar;
			return AddProgressBar(name, anchor, width, height, value, maximum, minimum, fillChar, emptyChar, defs.FillColor, defs.EmptyColor, true);
		}

		public TUIObjectBuilder AddProgressBar(string name, Anchor anchor, int width, int height, int value, int maximum, int minimum)
		{
			var defs = Defaults.DefaultProgressBar;
			return AddProgressBar(name, anchor, width, height, value, maximum, minimum, defs.FillChar, defs.FillChar);
		}
		public TUIObjectBuilder AddProgressBar(string name, Anchor anchor, int width, int height)
		{
			var defs = Defaults.DefaultProgressBar;
			return AddProgressBar(name, anchor, width, height, defs.DefaultValue, defs.DefaultMaxValue, defs.DefaultMinValue);
		}
		public TUIObjectBuilder AddProgressBar(string name,  int width, int height)
		{
			var defs = Defaults.DefaultProgressBar;
			return AddProgressBar(name, Defaults.DefaultAnchor, width, height);
		}
	}
}

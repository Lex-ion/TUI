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
		public TUIObjectBuilder AddPathSelector(string name, int width, int height, Anchor anchor, string text, bool isEnabled, Color interactionForeGround, Color interactionBackGround, Color foreColor, Color backColor, Color writingColorFore, Color writingColorBack, Color selectionColor)
		{
			if (height < 4)
				throw new ArgumentException("Height must be greater than 4");
			if (width < 1)
				throw new ArgumentException("Width must be greater than 1");

			TUIPathSelectorPart ps = new(name, anchor, width, height, text, 0, foreColor, backColor, interactionForeGround, interactionBackGround, isEnabled, TUIObjectPartType.PATH_SELECTOR, '_', '*', writingColorFore, writingColorBack, selectionColor);
			Product.AddPart(ps);
			return this;
		}
		public TUIObjectBuilder AddPathSelector(string name, int width, int height, Anchor anchor, string text)
		{
			var defs = Defaults.DefaultTUIPathSelector.TextBoxDefaults;
			return AddPathSelector(name, width, height, anchor, text, true, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, defs.WritingColorFore, defs.WritingColorBack, Defaults.DefaultTUIPathSelector.SelectionBackGrDefault);
		}
		public TUIObjectBuilder AddPathSelector(string name, int width, int height, Anchor anchor)
		{
			var defs = Defaults.DefaultTUIPathSelector.TextBoxDefaults;
			return AddPathSelector(name, width, height, anchor, "");
		}
		public TUIObjectBuilder AddPathSelector(string name, int width, int height)
		{
			return AddPathSelector(name, width, height, Defaults.DefaultAnchor);
		}


	}
}

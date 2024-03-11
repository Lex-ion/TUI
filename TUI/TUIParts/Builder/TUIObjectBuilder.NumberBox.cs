using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts.Builder
{
    public partial class TUIObjectBuilder
	{
		public TUIObjectBuilder AddNumberBox(string name, int width, Anchor anchor, int value, int max, int min, bool isEnabled, Color interactionForeGround, Color interactionBackGround, Color foreColor, Color backColor,Color writingFore, Color writingBack)
		{
			TUINumberBoxPart nb = new(name, anchor, width, value, max, min, foreColor, backColor, interactionForeGround, interactionBackGround,writingFore,writingBack, Defaults.DefaultBlankColor, (bool)isEnabled, TUIObjectPartType.NUMBER_BOX);
			Product.AddPart(nb);
			return this;
		}
		public TUIObjectBuilder AddNumberBox(string name, int width, Anchor anchor, int value, int max, int min)
		{
			var defs = Defaults.NumberBoxDefaults;
			return AddNumberBox(name,width,anchor,value,max,min,true,defs.CursorForeColor,defs.CursorBackColor,defs.ForeColor,defs.BackColor,defs.WritingColorFore,defs.WritingColorBack);
		}
		public TUIObjectBuilder AddNumberBox(string name, int width, Anchor anchor)
		{
			var defs = Defaults.NumberBoxDefaults;
			return AddNumberBox(name, width, anchor, defs.DefaultValue, defs.MaxValue, defs.MinValue);
		}
		public TUIObjectBuilder AddNumberBox(string name, int width)
		{
			var defs = Defaults.NumberBoxDefaults;
			return AddNumberBox(name, width,Defaults.DefaultAnchor);
		}
	}
}

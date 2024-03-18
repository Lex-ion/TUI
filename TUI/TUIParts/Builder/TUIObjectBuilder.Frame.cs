using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Defaults;
using TUI.Structs;

namespace TUI.TUIParts.Builder
{
    public partial class TUIObjectBuilder
	{
		public TUIObjectBuilder AddFrame(string name, int width, int height, Anchor anchor, TUIFrameStyle style, Color foreColor, Color backColor , bool isEnabled)
		{
			width += 2;
			height += 2;
			TUIFramePart frame = new(name, anchor, width, height, style, foreColor, backColor, Defaults.DefaultBlankColor, isEnabled, TUIObjectPartType.FRAME);
			Product.AddPart(frame);
			return this;
		}

		public TUIObjectBuilder AddFrame(string name, int width, int height, Anchor anchor, Color foreColor, Color backColor)
		{
			AddFrame(name, width, height, anchor,TUIFrameStyle.GetStyle("single"), foreColor, backColor,true);
			return this;
		}
		public TUIObjectBuilder AddFrame(string name, int width, int height, Anchor anchor)
		{
			var defs = Defaults.DefaultFrame;
			AddFrame(name, width, height, anchor, TUIFrameStyle.GetStyle("single"), defs.DefaultForeGroundColor, defs.DefaultBackGroundColor ,true);
			return this;
		}
		public TUIObjectBuilder AddFrame(string name, int width, int height)
		{
			var defs = Defaults.DefaultFrame;

			AddFrame(name,width,height,Defaults.DefaultAnchor,defs.DefaultForeGroundColor,defs.DefaultBackGroundColor);
			return this;
		}
		public TUIObjectBuilder AddFrame(string name, int width, int height, Anchor anchor, TUIFrameStyle style)
		{
			var defs = Defaults.DefaultFrame;
			AddFrame(name, width, height, anchor, style, defs.DefaultForeGroundColor, defs.DefaultBackGroundColor, true);
			return this;
		}

	}
}

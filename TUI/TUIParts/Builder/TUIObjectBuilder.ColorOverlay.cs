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
		public TUIObjectBuilder AddColorOverlay(string name, int width, int height, Color color, Anchor anchor)
		{

			TUIColorOverlay co = new(name, anchor, width, height, color, color, Defaults.DefaultBlankColor, true, TUIObjectPartType.COLOR_OVERLAY);
			Product.AddPart(co);
			return this;
		}
		public TUIObjectBuilder AddColorOverlay(string name, int width, int height, Color color)
		{
			return AddColorOverlay(name,width,height,color,Defaults.DefaultAnchor);
		}
	}
}

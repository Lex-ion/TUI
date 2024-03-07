using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts.Builder
{
	public partial class TUIObjectBuilder //Label addon
	{

		public TUIObjectBuilder AddLabel(string name, string? content, Anchor? anchor, int maxLineLength, Color foreColor , Color backColor , bool isEnabled)
		{
			ValidateName(name);
			anchor ??= Defaults.DefaultAnchor; 
			
			TUILabelPart label = new(name, anchor, content, maxLineLength, foreColor, backColor, isEnabled, TUIObjectPartType.LABEL);
			Product.AddPart(label);
			return this;
		}
		public TUIObjectBuilder AddLabel(string name, string? content)
		{
			AddLabel(name, content, Defaults.DefaultAnchor, 0, Defaults.DefaultForeGroundColor, Defaults.DefaultBackGroundColor, true);
			return this;
		}

		public TUIObjectBuilder AddLabel(string name, string? content, Anchor? anchor)
		{
			AddLabel(name, content, anchor, 0, Defaults.DefaultForeGroundColor, Defaults.DefaultBackGroundColor, true);
			return this;
		}
		public TUIObjectBuilder AddLabel(string name, string? content, Anchor? anchor, int maxLineLength)
		{
			AddLabel(name, content, anchor, maxLineLength, Defaults.DefaultForeGroundColor, Defaults.DefaultBackGroundColor, true);
			return this;
		}

	}
}

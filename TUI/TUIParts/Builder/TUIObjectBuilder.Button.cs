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
		

		public TUIObjectBuilder AddButton(string name, string? content, Anchor anchor, Color interactionForeGround, Color interactionBackGround , Color foreColor , Color backColor, bool isEnabled )
		{
			TUIButtonPart button = new(name, anchor, content, foreColor, backColor, interactionForeGround, interactionBackGround, isEnabled, TUIObjectPartType.BUTTON);
			Product.AddPart(button);
			return this;
		}
		public TUIObjectBuilder AddButton(string name, string? content, Anchor anchor, Color foreColor, Color backColor)
		{
			var defs = Defaults.DefaultButton;
			AddButton(name, content, anchor, defs.CursorForeColor, defs.CursorBackColor, foreColor, backColor, true);
			
			return this;
		}
		public TUIObjectBuilder AddButton(string name, string? content, Anchor anchor)
		{
			var defs = Defaults.DefaultButton;
			AddButton(name, content, anchor, defs.CursorForeColor, defs.CursorBackColor);
			return this;
		}
		public TUIObjectBuilder AddButton(string name, string? content)
		{
			AddButton(name, content, Defaults.DefaultAnchor);
			return this;
		}
		public TUIObjectBuilder AddButton(string name, string? content,Action action)
		{
			AddButton(name, content, Defaults.DefaultAnchor);
			Product.TUIInteractable!.Interacted += action;
			return this;
		}

	}
}

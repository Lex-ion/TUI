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
		public TUIObjectBuilder AddRadioButton(string name, int radioFamily, string content, bool isTicked, Anchor anchor , Color interactionForeGround, Color interactionBackGround , Color foreColor, Color backColor, bool isEnabled)
		{

			TUIRadioButtonPart rb = new(name, radioFamily, content, isTicked, anchor, foreColor, backColor, interactionForeGround, interactionBackGround, Defaults.DefaultBlankColor, isEnabled, TUIObjectPartType.RADIO_BUTTON);
			Product.AddPart(rb);
			return this;
		}
		public TUIObjectBuilder AddRadioButton(string name, int radioFamily, string content, bool isTicked, Anchor anchor)
		{
			var defs = Defaults.DefaultRadioButton;
			return AddRadioButton(name, radioFamily, content, isTicked, anchor, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, true);
		}
		public TUIObjectBuilder AddRadioButton(string name, int radioFamily, string content, bool isTicked)
		{
			return AddRadioButton(name, radioFamily, content, isTicked, Defaults.DefaultAnchor);
		}
		public TUIObjectBuilder AddRadioButton(string name, int radioFamily, string content)
		{
			return AddRadioButton(name, radioFamily, content, false);
		}

		public TUIObjectBuilder AddRadioButton(string name, int radioFamily, string content , Anchor anchor)
		{
			var defs = Defaults.DefaultRadioButton;
			return AddRadioButton(name, radioFamily, content, false, anchor, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, true);
		}
	}
}

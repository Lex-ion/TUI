using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts.Builder
{
	public partial class TUIObjectBuilder//TextBox addon
	{
		public TUIObjectBuilder AddTextBox(string name, int width, int height, Anchor? anchor, string? text, int maxChars, bool isEnabled , Color interactionForeGround , Color interactionBackGround , Color foreColor , Color backColor,char freeSpaceChar,char secretChar, Color writingColFore, Color writingColBack)
		{
			ValidateName(name);

			if (height < 1||width<1)
			{
				throw new ArgumentException("Height or width can not be less then 1!");
			}
			
			anchor ??= Defaults.DefaultAnchor;

			TUITextBoxPart tb = new(name, anchor, width, (int)height, text!, maxChars, (Color)foreColor, (Color)backColor, (Color)interactionForeGround, (Color)interactionBackGround, isEnabled, TUIObjectPartType.PROGRESS_BAR,freeSpaceChar,secretChar,writingColFore,writingColBack);
			Product.AddPart(tb);

			return this;
		}

		public TUIObjectBuilder AddTextBox(string name, int width, int height)
		{
			AddTextBox(name, width, height, Defaults.DefaultAnchor, "", 0, true, Defaults.DefaultTextBox.CursorForeColor, Defaults.DefaultTextBox.CursorBackColor, Defaults.DefaultTextBox.ForeColor, Defaults.DefaultTextBox.BackColor, Defaults.DefaultTextBox.FreespaceChar, Defaults.DefaultTextBox.HiddenChar, Defaults.DefaultTextBox.WritingColorFore, Defaults.DefaultTextBox.WritingColorBack);
			return this;
		}
		public TUIObjectBuilder AddTextBox(string name, int width, int height,Anchor? anchor)
		{
			var defs = Defaults.DefaultTextBox;
			AddTextBox(name, width, height, anchor, "", 0, true, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, defs.FreespaceChar, defs.HiddenChar, defs.WritingColorFore, defs.WritingColorBack);
			return this;
		}
		public TUIObjectBuilder AddTextBox(string name, int width, int height,int maxChars)
		{
			var defs = Defaults.DefaultTextBox;
			AddTextBox(name, width, height, Defaults.DefaultAnchor, "", 0, true, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, defs.FreespaceChar, defs.HiddenChar, defs.WritingColorFore, defs.WritingColorBack);
			return this;
		}
	}
}

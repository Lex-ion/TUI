using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Defaults
{
	public class TUITextBoxDefaults
	{
		public Color ForeColor { get; set; }
		public Color BackColor { get; set; }
		public Color CursorForeColor { get; set; }
		public Color CursorBackColor { get; set; }

		public Color WritingColorBack { get; set; }
		public Color WritingColorFore { get; set; }

		public char FreespaceChar { get; set; }
		public char HiddenChar { get; set; }

		public TUITextBoxDefaults(Color foreColor, Color backColor, Color cursorForeColor, Color cursorBackColor, Color writingColorFore, Color writingColorBack, char freespaceChar, char hiddenChar)
		{
			ForeColor = foreColor;
			BackColor = backColor;
			CursorForeColor = cursorForeColor;
			CursorBackColor = cursorBackColor;
			WritingColorBack = writingColorBack;
			WritingColorFore = writingColorFore;
			FreespaceChar = freespaceChar;
			HiddenChar = hiddenChar;
		}

		public TUITextBoxDefaults()
		{
			ForeColor = Color.DarkBlue;
			BackColor = Color.DarkGray;
			CursorForeColor = Color.White;
			CursorBackColor = Color.DarkMagenta;

			WritingColorBack = Color.Yellow;
			WritingColorFore = ForeColor;

			FreespaceChar = '_';
			HiddenChar = '*';
		}
	}
}

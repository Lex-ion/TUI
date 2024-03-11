using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Defaults
{
	public class TUINumberBoxDefaults
	{

		public int MaxValue {  get; set; }
		public int MinValue { get; set; }
		public int DefaultValue { get; set; }
		public Color ForeColor { get; set; }
		public Color BackColor { get; set; }
		public Color CursorForeColor { get; set; }
		public Color CursorBackColor { get; set; }

		public Color WritingColorBack { get; set; }
		public Color WritingColorFore { get; set; }

		public TUINumberBoxDefaults(int maxValue, int minValue, int defaultValue, Color foreColor, Color backColor, Color cursorForeColor, Color cursorBackColor, Color writingColorBack, Color writingColorFore)
		{
			MaxValue = maxValue;
			MinValue = minValue;
			DefaultValue = defaultValue;
			ForeColor = foreColor;
			BackColor = backColor;
			CursorForeColor = cursorForeColor;
			CursorBackColor = cursorBackColor;
			WritingColorBack = writingColorBack;
			WritingColorFore = writingColorFore;
		}

		public TUINumberBoxDefaults()
		{
			MaxValue = int.MaxValue;
			MinValue = int.MinValue;
			DefaultValue = 0;

			ForeColor = Color.DarkBlue;
			BackColor = Color.DarkGray;
			CursorForeColor = Color.White;
			CursorBackColor = Color.DarkMagenta;

			WritingColorBack = Color.Yellow;
			WritingColorFore = ForeColor;
		}
	}
}

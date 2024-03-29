﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Defaults
{
	public class TUIButtonDefaults
	{
		public Color ForeColor { get; set; }
		public Color BackColor { get; set; }
		public Color CursorForeColor { get; set; }
		public Color CursorBackColor { get; set; }

		public TUIButtonDefaults(Color foreColor, Color backColor, Color cursorForeColor, Color curosorBackColor)
		{
			ForeColor = foreColor;
			BackColor = backColor;
			CursorForeColor = cursorForeColor;
			CursorBackColor = curosorBackColor;
		}

		public TUIButtonDefaults() 
		{ 
			ForeColor = Color.DarkBlue;
			BackColor = Color.DarkGray;
			CursorForeColor = Color.White;
			CursorBackColor = Color.DarkMagenta;
		}
	}
}

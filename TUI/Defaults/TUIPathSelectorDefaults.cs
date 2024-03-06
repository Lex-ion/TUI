using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TUI.Defaults
{
	public class TUIPathSelectorDefaults
	{
		public TUITextBoxDefaults TextBoxDefaults { get; set; }
		public Color SelectionBackGrDefault { get; set; }

		public TUIPathSelectorDefaults(TUITextBoxDefaults textBoxDefaults, Color selectionDefaults)
		{
			TextBoxDefaults = textBoxDefaults;
			SelectionBackGrDefault = selectionDefaults;
		}
		public TUIPathSelectorDefaults() {
			TextBoxDefaults = new();
			SelectionBackGrDefault =Color.Lime;
		}
	}
}

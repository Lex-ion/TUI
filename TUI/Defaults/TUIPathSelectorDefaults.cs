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
		public Color SelectionDefaults { get; set; }

		public TUIPathSelectorDefaults(TUITextBoxDefaults textBoxDefaults, Color selectionDefaults)
		{
			TextBoxDefaults = textBoxDefaults;
			SelectionDefaults = selectionDefaults;
		}
	}
}

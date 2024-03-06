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
		public Color InteractionForeColor { get; set; }
		public Color InteractionBackColor { get; set; }

		public char FreespaceChar { get; set; }
		public char HiddenChar { get; set; }

		public TUITextBoxDefaults()
		{
			throw new NotImplementedException();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Defaults
{
	public class TUIProgressBarDefaults
	{
		public int DefaultValue { get; set; }
		public int DefaultMaxValue { get; set; }
		public int DefaultMinValue { get; set; } 

		public Color FillColor { get; set; }
		public Color EmptyColor { get; set; }

		public TUIProgressBarDefaults(int defaultValue, int defaultMaxValue, int defaultMinValue, Color fillColor, Color emptyColor)
		{
			DefaultValue = defaultValue;
			DefaultMaxValue = defaultMaxValue;
			DefaultMinValue = defaultMinValue;
			FillColor = fillColor;
			EmptyColor = emptyColor;
		}
		public TUIProgressBarDefaults()
		{

			DefaultValue = 0;
			DefaultMaxValue = 100;
			DefaultMinValue = 0;
			FillColor = Color.DarkOrange;
			EmptyColor = Color.DarkViolet;
		}

	}
}

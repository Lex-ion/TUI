using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using TUI.Structs;
using System.Drawing;

namespace TUI.TUIParts.Builder
{
	public partial class TUIObjectBuilder
	{
		public TUIObjectBuilder AddFileSelector(string name, int width, int height, Anchor anchor,Regex fileNameRegex ,string text, bool isEnabled, Color interactionForeGround, Color interactionBackGround, Color foreColor, Color backColor, Color writingColorFore, Color writingColorBack, Color selectionColor)
		{

			if (height < 4)
				throw new ArgumentException("Height must be greater than 4");
			if (width < 1)
				throw new ArgumentException("Width must be greater than 1");


			Regex r = new($".*");
			TUIFileSelectorPart fs = new(name,fileNameRegex, anchor, width, height, text, 0, foreColor, backColor, interactionForeGround, interactionBackGround, Defaults.DefaultBlankColor, isEnabled, TUIObjectPartType.PATH_SELECTOR, '_', '*', writingColorFore, writingColorBack, selectionColor);
			Product.AddPart( fs );
			return this;
		}

		public TUIObjectBuilder AddFileSelector(string name, int width, int height, Anchor anchor,Regex fileNameRegex, string text)
		{
			var defs = Defaults.DefaultTUIPathSelector.TextBoxDefaults;
			return AddFileSelector(name, width, height, anchor, fileNameRegex, text, true, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, defs.WritingColorFore, defs.WritingColorBack, Defaults.DefaultTUIPathSelector.SelectionBackGrDefault);
		}
		public TUIObjectBuilder AddFileSelector(string name, int width, int height, Anchor anchor, Regex fileNameRegex)
		{
			var defs = Defaults.DefaultTUIPathSelector.TextBoxDefaults;
			return AddFileSelector(name, width, height, anchor, fileNameRegex, "", true, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, defs.WritingColorFore, defs.WritingColorBack, Defaults.DefaultTUIPathSelector.SelectionBackGrDefault);
		}
		public TUIObjectBuilder AddFileSelector(string name, int width, int height, Anchor anchor)
		{
			var defs = Defaults.DefaultTUIPathSelector.TextBoxDefaults;
			return AddFileSelector(name, width, height, anchor, new Regex(".*"), "", true, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, defs.WritingColorFore, defs.WritingColorBack, Defaults.DefaultTUIPathSelector.SelectionBackGrDefault);
		}
		public TUIObjectBuilder AddFileSelector(string name, int width, int height)
		{
			var defs = Defaults.DefaultTUIPathSelector.TextBoxDefaults;
			return AddFileSelector(name, width, height, Defaults.DefaultAnchor, new Regex(".*"), "", true, defs.CursorForeColor, defs.CursorBackColor, defs.ForeColor, defs.BackColor, defs.WritingColorFore, defs.WritingColorBack, Defaults.DefaultTUIPathSelector.SelectionBackGrDefault);
		}
	}
}

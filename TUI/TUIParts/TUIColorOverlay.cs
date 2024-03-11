using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
	public class TUIColorOverlay : AbstractTUIObjectPart
	{
		
		public TUIColorOverlay(string name, Anchor? anchor, int width, int height, Color foreColor, Color backColor, Color clearingColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor,clearingColor, isEnabled, partType)
		{
		}
		public override bool Draw(Anchor parentAnchor)
		{
			if (!base.Draw(parentAnchor))
				return false;

			if (!SetCursor(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top))
				return false;

			for (int i = 0; i < Height; i++)
			{
				if (!SetCursor(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top+i))
					return true;
				for (int j = 0; j < Width; j++)
				{
					if (!SetCursor(Anchor.Left + parentAnchor.Left+j, Anchor.Top + parentAnchor.Top+i))
						break;
					Console.Write(' ');
				}
			}

			return true;
		}
	}
}

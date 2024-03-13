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
		public bool UseUnsafeDrawing { get; set; }
		public TUIColorOverlay(string name, Anchor? anchor, int width, int height, Color foreColor, Color backColor, Color clearingColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor,clearingColor, isEnabled, partType)
		{
			UseUnsafeDrawing = false;
		}
		public override bool Draw(Anchor parentAnchor)
		{
			if(UseUnsafeDrawing)
			{
				UnsafeDraw(parentAnchor);
				return true;
			}


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

		public void UnsafeDraw(Anchor parentAnchor)
		{
			UseColors();
			for (int i = 0; i < Height; i++)
			{
					Console.SetCursorPosition(Anchor.Left + parentAnchor.Left , Anchor.Top + parentAnchor.Top + i);
					Console.Write(new string (' ',Width));
				
			}
		}
	}
}

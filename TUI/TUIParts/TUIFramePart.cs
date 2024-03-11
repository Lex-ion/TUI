using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Defaults;
using TUI.Structs;

namespace TUI.TUIParts
{
    internal class TUIFramePart : AbstractTUIObjectPart
    {
        public TUIFramePart(string name, Anchor? anchor, int width, int height, TUIFrameStyle style, Color foreColor, Color backColor,Color clearingColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor,clearingColor, isEnabled, partType)
        {
            Style = style;
        }


        public TUIFrameStyle Style { get; protected set; }


        /// <summary>
        /// Draws frame around object. Anchor is top left corner.
        /// </summary>
        /// <param name="parentAnchor">Parent anchor to offset from</param>
        public override bool Draw(Anchor parentAnchor)
        {
            if (!base.Draw(parentAnchor))
                return false;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {


                    if (i > 0 && i < Width - 1 && j > 0 && j < Height - 1)
                        continue;


                    if (!SetCursor(parentAnchor.Left + Anchor.Left + i, parentAnchor.Top + Anchor.Top + j))
                        continue;
                    if (j == 0 && i == 0)
                        Console.Write(Style.TLCorner);
                    else if (j == 0 && i == Width - 1)
                        Console.Write(Style.TRCorner);
                    else if (j == Height - 1 && i == 0)
                        Console.Write(Style.BLCorner);
                    else if (j == Height - 1 && i == Width - 1)
                        Console.Write(Style.BRCorner);
                    else if (j == 0)
                        Console.Write(Style.TopWall);
                    else if (j == Height - 1)
                        Console.Write(Style.BottomWall);
                    else if (i == 0)
                        Console.Write(Style.LeftWall);
                    else if (i == Width - 1)
                        Console.Write(Style .RightWall);
                }
            }
            Console.CursorVisible = false;
            return true;
        }

    }
}

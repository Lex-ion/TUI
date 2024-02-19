using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    internal class TUIFramePart : AbstractTUIObjectPart, ITUIColorsSet
    {

        public FrameOptions Options { get; protected set; }

        public ConsoleColor ForeGround { get; protected set; }
        public ConsoleColor BackGround { get; protected set; }

        public bool BackGroundSet { get; private set; }

        public bool ForeGroundSet { get; private set; }

        public void Set(string name, int height, int width, Anchor anchor, FrameOptions options, ConsoleColor? foreGround = null, ConsoleColor? backGround = null)
        {
            Height = height;
            Width = width;

            Options = options;

            Name = name;
            Anchor = anchor;
            IsEnabled = true;
            PartType = TUIObjectPartType.LABEL;

            if (foreGround != null)
                SetForeGroundColor((ConsoleColor)foreGround);
            if (backGround != null)
                SetBackGroundColor((ConsoleColor)backGround);
        }

        public void SetColors(ConsoleColor foreGround, ConsoleColor backGround)
        {
            ForeGround = foreGround;
            BackGround = backGround;
            ForeGroundSet = true;
            BackGroundSet = true;

        }

        public void SetForeGroundColor(ConsoleColor foreGround)
        {
            ForeGround = foreGround;
            ForeGroundSet = true;
        }

        public void SetBackGroundColor(ConsoleColor backGround)
        {
            BackGround = backGround;
            BackGroundSet = true;
        }


        /// <summary>
        /// Draws frame around object. Anchor is top left corner.
        /// </summary>
        /// <param name="parentAnchor">Parent anchor to offset from</param>
        public override void Draw(Anchor parentAnchor)
        {
            Console.ForegroundColor = ForeGround;
            Console.BackgroundColor = BackGround;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {


                    if (i > 0 && i < Width - 1 && j > 0 && j < Height - 1)
                        continue;


                    if (!SetCursor(parentAnchor.Left + Anchor.Left + i, parentAnchor.Top + Anchor.Top + j))
                        continue;
                    if (j == 0 && i == 0)
                        Console.Write(Options.TLCorner);
                    else if (j == 0 && i == Width - 1)
                        Console.Write(Options.TRCorner);
                    else if (j == Height - 1 && i == 0)
                        Console.Write(Options.BLCorner);
                    else if (j == Height - 1 && i == Width - 1)
                        Console.Write(Options.BRCorner);
                    else if (j == 0)
                        Console.Write(Options.TopWall);
                    else if (j == Height - 1)
                        Console.Write(Options.BottomWall);
                    else if (i == 0)
                        Console.Write(Options.LeftWall);
                    else if (i == Width - 1)
                        Console.Write(Options.RightWall);
                }
            }
            Console.CursorVisible = false;
        }

    }
}

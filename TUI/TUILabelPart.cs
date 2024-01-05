using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    public class TUILabelPart : AbstractTUIObjectPart,ITUILabel
    {
        public void Set(string name, Anchor anchor, string? content, ConsoleColor? foreGround = null, ConsoleColor? backGround = null) 
        {
            Content = content;

            Name = name;
            Anchor = anchor;
            Enabled = true;
            PartType = TUIObjectPartType.LABEL;

            if (foreGround != null)
                SetForeGroundColor((ConsoleColor)foreGround);
            if(backGround != null)
                SetBackGroundColor((ConsoleColor)backGround);
        }

        private string? _content;

        /// <summary>
        /// Text of label
        /// </summary>
        public string? Content  { get { return _content is null?"":_content; } set { _content = value; }}

        public ConsoleColor ForeGround { get; set ; }
        public ConsoleColor BackGround { get ; set ; }

        public bool BackGroundSet { get; private set ; }

        public bool ForeGroundSet { get; private set; }

        public override void Draw(Anchor parentAnchor)
        {
            Anchor pos = new(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top);
            if (pos.Left < 0 || pos.Left >= Console.BufferWidth)
                return;
            if (pos.Top < 0 || pos.Top >= Console.BufferHeight)
                return;

            Console.ForegroundColor = ForeGround;
            Console.BackgroundColor = BackGround;
            Console.SetCursorPosition(pos.Left,pos.Top);
            Console.Write(Content);
        }

        public void SetColors(ConsoleColor foreGround, ConsoleColor backGround)
        {
            ForeGround=foreGround;
            BackGround=backGround;
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
    }
}

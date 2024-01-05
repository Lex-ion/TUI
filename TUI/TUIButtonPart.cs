using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    internal class TUIButtonPart : AbstractTUIInteractivePart,ITUILabel
    {

        private string? _content;

        /// <summary>
        /// Text of button
        /// </summary>
        public string? Content { get { return _content is null ? "" : _content; } set { _content = value; } }
        /// <summary>
        /// OLD
        /// </summary>
        public Action? Action { get; set; }


        public override void Draw(Anchor parentAnchor)
        {
            if (!SetCursor(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top))
                return;

            if (!Selected)
            {
                Console.ForegroundColor = ForeGround;
                Console.BackgroundColor = BackGround;
            }else
            {
                Console.ForegroundColor = OnCursorColorFore;
                Console.BackgroundColor = OnCursorColorBack;
            }
            
            Console.Write(Content);
        }
        public override void Interact()
        {
            base.Interact();
            if (!Selected)
                return;
            Action?.Invoke();
        }



    }
}

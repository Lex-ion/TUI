using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    public abstract class AbstractTUIObjectPart : ITUIObjectPart
    {
       
        /// <summary>
        /// Name of Part
        /// </summary>
        public string Name { get;protected set; }
        /// <summary>
        /// Anchor for object so it knows where to draw. Offsets from parent Anchor
        /// </summary>
        public Anchor Anchor { get; set; }
        public bool Enabled { get;  set; }

        public TUIObjectPartType PartType { get; protected set; }

        
        /// <summary>
        /// Draws part
        /// </summary>
        /// <param name="parentAnchor">Parent anchor to offset from</param>
        public abstract void Draw(Anchor parentAnchor);

        public bool SetCursor(int left,int top)
        {
            Anchor pos = new(left,top);
            if (pos.Left < 0 || pos.Left >= Console.BufferWidth)
                return false;
            if (pos.Top < 0 || pos.Top >= Console.BufferHeight)
                return false;

            Console.SetCursorPosition(pos.Left,pos.Top);

            return true;
        }
    }
}

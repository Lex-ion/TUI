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
        public event Action? Resized;
        public event Action? Enabled;
        public event Action? Disabled;
        public event Action? Moved;

        /// <summary>
        /// Name of Part
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// Anchor for object so it knows where to draw. Offsets from parent Anchor
        /// </summary>
        public Anchor Anchor
        {
            get => _anchor; set
            {
                _anchor = value;
                Moved?.Invoke();
            }
        }
        Anchor _anchor;
        public bool IsEnabled
        {
            get => _isEnabled; set
            {
                _isEnabled = value;
                if (value)
                    Enabled?.Invoke();
                else
                    Disabled?.Invoke();
            }
        }
        protected bool _isEnabled;

        public TUIObjectPartType PartType { get; protected set; }

        public virtual int Width
        {
            get => _width;
            set
            {
                _width = value;
                Resized?.Invoke();
            }
        }
        protected int _width;
        public virtual int Height
        {
            get => _height;
            set
            {
                _height = value;
                Resized?.Invoke();
            }
        }
        protected int _height;

        /// <summary>
        /// Draws part
        /// </summary>
        /// <param name="parentAnchor">Parent anchor to offset from</param>
        public abstract void Draw(Anchor parentAnchor);

        public bool SetCursor(int left, int top)
        {
            Anchor pos = new(left, top);
            if (pos.Left < 0 || pos.Left >= Console.BufferWidth)
                return false;
            if (pos.Top < 0 || pos.Top >= Console.BufferHeight)
                return false;

            Console.SetCursorPosition(pos.Left, pos.Top);

            return true;
        }
    }
}

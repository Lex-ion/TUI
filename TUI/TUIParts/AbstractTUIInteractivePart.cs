using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
    public abstract class AbstractTUIInteractivePart : AbstractTUIObjectPart, ITUIInteractable
    {
        public event Action? Interacted;
        public event Action? Selected;
        public event Action? UnSelected;

        public ConsoleColor OnCursorColorFore { get; set; }

        public ConsoleColor OnCursorColorBack { get; set; }

        public bool IsSelected
        {
            get => _isSelected; set
            {
                _isSelected = value;
                if (value)
                    Selected?.Invoke();
                else
                    UnSelected?.Invoke();
            }
        }
        bool _isSelected;
        protected AbstractTUIInteractivePart(string name, Anchor? anchor, int width, int height, ConsoleColor foreColor, ConsoleColor backColor, ConsoleColor onCursorColorFore, ConsoleColor onCursorColorBack, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor, isEnabled, partType)
        {
            OnCursorColorFore = onCursorColorFore;
            OnCursorColorBack = onCursorColorBack;
        }

        public virtual void Interact()
        {
            if (!IsSelected)
                return;
            Interacted?.Invoke();
        }

        public override void UseColors()
        {
            Console.ForegroundColor = IsSelected ? OnCursorColorFore : ForeColor;
            Console.BackgroundColor = IsSelected ? OnCursorColorBack : BackColor;
        }

    }
}

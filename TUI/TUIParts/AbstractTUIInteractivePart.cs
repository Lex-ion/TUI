using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Color OnCursorColorFore { get; set; }

        public Color OnCursorColorBack { get; set; }

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
        protected AbstractTUIInteractivePart(string name, Anchor? anchor, int width, int height, Color foreColor, Color backColor, Color onCursorColorFore, Color onCursorColorBack,Color clearingColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor,clearingColor, isEnabled, partType)
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
            if (IsSelected)
				Console.Write($"\u001b[48;2;{OnCursorColorBack.R};{OnCursorColorBack.G};{OnCursorColorBack.B};38;2;{OnCursorColorFore.R};{OnCursorColorFore.G};{OnCursorColorFore.B}m");
            else
                base.UseColors();
        }

    }
}

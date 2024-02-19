using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    public abstract class AbstractTUIInteractivePart : AbstractTUIObjectPart, ITUIInteractable, ITUIColorsSet
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


        public virtual void Interact()
        {
            if (!IsSelected)
                return;
            Interacted?.Invoke();
        }
        public ConsoleColor ForeGround { get; set; }
        public ConsoleColor BackGround { get; set; }

        public bool BackGroundSet { get; private set; }

        public bool ForeGroundSet { get; private set; }

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

        public virtual void Set(string name, Anchor anchor, ConsoleColor? foreGround = null, ConsoleColor? backGround = null, ConsoleColor? interactionForeGround = null, ConsoleColor? interactionBackGround = null)
        {
            Name = name;
            Anchor = anchor;
            IsEnabled = true;
            PartType = TUIObjectPartType.LABEL;



            if (foreGround != null)
                SetForeGroundColor((ConsoleColor)foreGround);
            if (backGround != null)
                SetBackGroundColor((ConsoleColor)backGround);
            if (interactionBackGround != null)
                OnCursorColorBack = ((ConsoleColor)interactionBackGround);
            if (interactionForeGround != null)
                OnCursorColorFore = ((ConsoleColor)interactionForeGround);
        }

    }
}

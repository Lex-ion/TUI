using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.TUIParts
{
    public interface ITUIInteractable
    {

        event Action? Interacted;
        event Action? Selected;
        event Action? UnSelected;


		Color OnCursorColorFore { get; }
		Color OnCursorColorBack { get; }
        void Interact();

        bool IsSelected { get; set; }

    }
}

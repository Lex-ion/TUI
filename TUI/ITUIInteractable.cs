using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI
{
    public interface ITUIInteractable
    {

        event Action? Interacted;
        event Action? Selected;
        event Action? UnSelected;


         ConsoleColor OnCursorColorFore { get; }
         ConsoleColor OnCursorColorBack { get; }
         void Interact();

         bool IsSelected { get; set; }
         
    }
}

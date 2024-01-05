using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI
{
    public interface ITUIInteractable
    {
         ConsoleColor OnCursorColorFore { get; }
         ConsoleColor OnCursorColorBack { get; }
         void Interact();

         event Action Interacted;
         bool Selected { get; set; }
         
    }
}

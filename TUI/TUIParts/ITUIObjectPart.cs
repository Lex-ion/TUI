using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
    public interface ITUIObjectPart
    {
        event Action? Resized;
        event Action? Enabled;
        event Action? Disabled;
        event Action? Moved;

        string Name { get; }
        Anchor Anchor { get; }
        bool IsEnabled { get; set; }
        public bool Draw(Anchor parentAnchor);

        TUIObjectPartType PartType { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    public interface ITUIObjectPart
    {
        string Name { get; }
        Anchor Anchor { get; }
        bool Enabled { get; set; }
        public void Draw(Anchor parentAnchor);

        TUIObjectPartType PartType { get; }
    }
}

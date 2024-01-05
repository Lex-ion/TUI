using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
     interface ITUIObjectBuilder
    {

        void Reset();
        TUIObject Build();
        ObjectBuilderDefaults Defaults { get; set; }
    }
}

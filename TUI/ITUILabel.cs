using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI
{
    interface ITUILabel:ITUIColorsSet
    {
        string? Content { get; set; }
    }
}

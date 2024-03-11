using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.TUIParts
{
    interface ITUILabel
    {
        public event Action? TextChanged;
        string? Content { get; set; }
    }
}

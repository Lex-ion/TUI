using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI
{
    interface ITUIColorsSet
    {
        bool BackGroundSet { get;}
        bool ForeGroundSet { get;}
        void SetColors(ConsoleColor foreGround, ConsoleColor backGround);
        void SetForeGroundColor(ConsoleColor foreGround);
        void SetBackGroundColor(ConsoleColor backGround);
    }
}

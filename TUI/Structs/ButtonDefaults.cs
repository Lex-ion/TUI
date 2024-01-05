using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Structs
{
    public struct ButtonDefaults
    {
        public ButtonDefaults(ConsoleColor foreGround, ConsoleColor background, ConsoleColor interactionForeGround, ConsoleColor interactionBackground)
        {
            ForeGround = foreGround;
            Background = background;
            InteractionForeGround = interactionForeGround;
            InteractionBackground = interactionBackground;
        }

        public ButtonDefaults()
        {
            ForeGround = ConsoleColor.DarkBlue;
            Background = ConsoleColor.DarkGray;
            InteractionForeGround = ConsoleColor.White;
            InteractionBackground = ConsoleColor.DarkMagenta;
        }

        public ConsoleColor ForeGround { get; set; }
        public ConsoleColor Background { get; set; }
        public ConsoleColor InteractionForeGround { get; set; }
        public ConsoleColor InteractionBackground { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Structs
{
    internal class TextBoxDefaults
    {
        public TextBoxDefaults(ConsoleColor foreGround, ConsoleColor background, ConsoleColor interactionForeGround, ConsoleColor interactionBackground, ConsoleColor writingForeGround, ConsoleColor writingBackground)
        {
            ForeGround = foreGround;
            Background = background;
            InteractionForeGround = interactionForeGround;
            InteractionBackground = interactionBackground;
            WritingForeGround= writingForeGround;
            WritingBackground= writingBackground;
        }

        public TextBoxDefaults()
        {
            ForeGround = ConsoleColor.DarkBlue;
            Background = ConsoleColor.DarkGray;
            InteractionForeGround = ConsoleColor.White;
            InteractionBackground = ConsoleColor.DarkMagenta;
            WritingForeGround = ConsoleColor.White;
            WritingBackground = ConsoleColor.DarkYellow;
        }

        public ConsoleColor ForeGround { get; set; }
        public ConsoleColor Background { get; set; }
        public ConsoleColor InteractionForeGround { get; set; }
        public ConsoleColor InteractionBackground { get; set; }

        public ConsoleColor WritingForeGround { get; set; }
        public ConsoleColor WritingBackground { get; set; }

    }
}

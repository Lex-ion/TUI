using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Structs
{
    /// <summary>
    /// Struct that represents origin point for object or part.
    /// </summary>
    public struct Anchor
    {
        /// <summary>
        /// Customized Anchor
        /// </summary>
        /// <param name="left">Chars to left from parent Anchor </param>
        /// <param name="top">Chars top from parent Anchor. Using inverted values sucha as Console.Cursor position. </param>
        public Anchor(int left, int top)
        {
            Left = left;
            Top = top;
        }

        /// <summary>
        /// Default Anchor
        /// </summary>
        public Anchor()
        {
            Left = 0;
            Top = 0;
        }
        /// <summary>
        /// Chars to left from parent Anchor
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// Chars top from parent Anchor. Using inverted values sucha as Console.Cursor position.
        /// </summary>
        public int Top { get; set; }
    }
}

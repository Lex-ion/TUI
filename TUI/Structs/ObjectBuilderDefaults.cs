using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Structs
{
    /// <summary>
    /// Default values for object builder to use, when you are not using custom.
    /// </summary>
    public struct ObjectBuilderDefaults
    {
        /// <summary>
        /// Fully customized defaults
        /// </summary>
        /// <param name="foreGround"></param>
        /// <param name="backGround"></param>
        /// <param name="anchor"></param>
        /// <param name="frameOptions"></param>
        public ObjectBuilderDefaults(ConsoleColor foreGround, ConsoleColor backGround,Anchor anchor, FrameOptions frameOptions,ButtonDefaults buttonDefaults)
        {
            ForeGround = foreGround;
            BackGround = backGround;
            Anchor = anchor;
            FrameOptions = frameOptions;
            ButtonDefaults=buttonDefaults;
        }

        public ObjectBuilderDefaults(ConsoleColor foreGround, ConsoleColor backGround)
        {
            ForeGround = foreGround;
            BackGround = backGround;
            Anchor = new();
            FrameOptions = new();
            ButtonDefaults = new();
        }
        /// <summary>
        /// Defaults
        /// </summary>
        public ObjectBuilderDefaults()
        {
            ForeGround = ConsoleColor.Gray;
            BackGround= ConsoleColor.Black;
            Anchor = new();
            FrameOptions=new();
            ButtonDefaults=new();
        }
        /// <summary>
        /// Default foreground for parts
        /// </summary>
        public ConsoleColor ForeGround { get; set; }
        /// <summary>
        /// Default background for parts
        /// </summary>
        public ConsoleColor BackGround { get; set; }
        /// <summary>
        /// Default anchor for parts
        /// </summary>
        public Anchor Anchor { get; set; }
        /// <summary>
        /// Options for frame part
        /// </summary>
        public FrameOptions FrameOptions { get; set; }

        public ButtonDefaults ButtonDefaults { get; set; }
    }
}

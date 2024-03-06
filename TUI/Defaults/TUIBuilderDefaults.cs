using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.Defaults
{

    public class TUIBuilderDefaults
    {
        public static TUIBuilderDefaults MasterDefault =new TUIBuilderDefaults();

        public Color DefaultForeGroundColor { get; set; }
        public Color DefaultBackGroundColor { get; set; }
        public Color DefaultBlankColor { get; set; }
        public Anchor DefaultAnchor { get; set; }

		public TUIButtonDefaults DefaultButton { get; set; }
		public TUIButtonDefaults DefaultRadioButton { get; set; }
		public TUIFrameDefaults DefaultFrame { get; set; }
        public TUIProgressBarDefaults DefaultProgressBar { get; set; }
        public TUITextBoxDefaults DefaultTextBox { get; set; }

		public TUIBuilderDefaults(Color defaultForeGroundColor, Color defaultBackGroundColor, Color defaultBlankColor, Anchor defaultAnchor, TUIButtonDefaults defaultButton, TUIButtonDefaults defaultRadioButton, TUIFrameDefaults defaultFrame, TUIProgressBarDefaults defaultProgressBar, TUITextBoxDefaults defaultTextBox)
		{
			DefaultForeGroundColor = defaultForeGroundColor;
			DefaultBackGroundColor = defaultBackGroundColor;
			DefaultBlankColor = defaultBlankColor;
			DefaultAnchor = defaultAnchor;
			DefaultButton = defaultButton;
			DefaultRadioButton = defaultRadioButton;
			DefaultFrame = defaultFrame;
			DefaultProgressBar = defaultProgressBar;
			DefaultTextBox = defaultTextBox;
		}

		public TUIBuilderDefaults()
        {
            DefaultRadioButton = DefaultButton;

        }


    }
}

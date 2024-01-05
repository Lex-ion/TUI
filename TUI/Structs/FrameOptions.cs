namespace TUI.Structs
{
    public class FrameOptions
    {
        public FrameOptions(char leftWall, char rightWall, char topWall, char bottomWall, char tRCorner, char tLCorner, char bRCorner, char bLCorner)
        {
            LeftWall = leftWall;
            RightWall = rightWall;
            TopWall = topWall;
            BottomWall = bottomWall;
            TRCorner = tRCorner;
            TLCorner = tLCorner;
            BRCorner = bRCorner;
            BLCorner = bLCorner;
        }
        public FrameOptions(char leftWall, char rightWall, char topWall, char bottomWall)
        {
            LeftWall = leftWall;
            RightWall = rightWall;
            TopWall = topWall;
            BottomWall = bottomWall;
            TRCorner = rightWall;
            TLCorner = leftWall;
            BRCorner = rightWall;
            BLCorner = leftWall;
        }
        public FrameOptions()
        {
            LeftWall = '║';
            RightWall = '║';
            TopWall = '═';
            BottomWall = '═';
            TRCorner = '╗';
            TLCorner = '╔';
            BRCorner = '╝';
            BLCorner = '╚';
        }

        public char LeftWall { get; set; }
        public char RightWall { get; set; }
        public char TopWall { get; set; }
        public char BottomWall { get; set; }

        public char TRCorner { get; set;     }
        public char TLCorner { get; set; }
        public char BRCorner { get; set; }
        public char BLCorner { get; set; }
    }
}

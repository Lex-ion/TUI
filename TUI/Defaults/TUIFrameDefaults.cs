using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Defaults
{
	public class TUIFrameDefaults
	{
		public Color DefaultForeGroundColor { get; set; }
		public Color DefaultBackGroundColor { get; set; }
		public TUIFrameStyle DefaultStyle { get; set; }

		public TUIFrameDefaults(Color defaultForeGroundColor, Color defaultBackGroundColor, TUIFrameStyle defaultStyle)
		{
			DefaultForeGroundColor = defaultForeGroundColor;
			DefaultBackGroundColor = defaultBackGroundColor;
			DefaultStyle = defaultStyle;
		}
		public TUIFrameDefaults() {
			DefaultForeGroundColor = Color.White;
			DefaultBackGroundColor = Color.Black;
			DefaultStyle = TUIFrameStyle.GetStyle("double");
		}
		public TUIFrameDefaults(Color defaultForeGroundColor, Color defaultBackGroundColor)
		{
			DefaultForeGroundColor = defaultForeGroundColor;
			DefaultBackGroundColor = defaultBackGroundColor;
			DefaultStyle = TUIFrameStyle.GetStyle("double");
		}
	}

	public class TUIFrameStyle
	{
		static Dictionary<string, char[]> Styles = new Dictionary<string, char[]>()
		{
			{"single",new char[] { '│', '│', '─', '─', '┐', '┌', '┘', '└' } },
			{"double",new char[] { '║', '║', '═', '═', '╗', '╔','╝', '╚' } },
			{"rounded",new char[] { '│', '│', '─', '─', '╮', '╭', '╯', '╰' } },
			{"doubledashed",new char[] { '╎', '╎', '╌', '╌', '┐', '┌', '┘', '└' } },
			{"trippledashed",new char[] { '┆', '┆', '┄', '┄', '┐', '┌', '┘', '└' } },
			{"quadrapledashed",new char[] { '┊', '┊', '┈', '┈', '┐', '┌', '┘', '└' } }

		};
		public static TUIFrameStyle GetStyle(string name)
		{
			char[] chars = Styles[name.ToLower()];
			return new(chars[0], chars[1], chars[2], chars[3], chars[4], chars[5], chars[6], chars[7]);
		}
		public static void SaveStyle(string name, TUIFrameStyle style)
		{
			char[] chars = {style.LeftWall,style.RightWall,style.TopWall,style.BottomWall,style.TRCorner,style.TLCorner,style.BRCorner,style.BLCorner};
			Styles.Add(name.ToLower(), chars);
		}

		public char LeftWall { get; set; }
		public char RightWall { get; set; }
		public char TopWall { get; set; }
		public char BottomWall { get; set; }
		public char TRCorner { get; set; }
		public char TLCorner { get; set; }
		public char BRCorner { get; set; }
		public char BLCorner { get; set; }

		public TUIFrameStyle(char leftWall, char rightWall, char topWall, char bottomWall, char tRCorner, char tLCorner, char bRCorner, char bLCorner)
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
		public TUIFrameStyle(char verticalWalls,char horizontalWalls, char tRCorner, char tLCorner, char bRCorner, char bLCorner) : this(verticalWalls,verticalWalls,horizontalWalls,horizontalWalls,tRCorner,tLCorner,bRCorner,bLCorner) 
		{
			//👀
		}
		

		public TUIFrameStyle(char walls,char corners) : this(walls,walls,corners, corners, corners, corners)
		{
			//💀
		}

		public TUIFrameStyle(char all) : this(all, all)
		{
			//🙄
		}

	}


}

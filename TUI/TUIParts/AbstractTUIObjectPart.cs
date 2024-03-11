using System.Drawing;
using TUI.Structs;

namespace TUI.TUIParts
{
	public abstract class AbstractTUIObjectPart : ITUIObjectPart
	{
		public event Action? Resized;
		public event Action? Enabled;
		public event Action? Disabled;
		public event Action? Moved;

		public static int BufferWidth { get; set; }
		public static int BufferHeight { get; set; }

		/// <summary>
		/// Name of Part
		/// </summary>
		public string Name { get; protected set; }
		/// <summary>
		/// Anchor for object so it knows where to draw. Offsets from parent Anchor
		/// </summary>
		public Anchor Anchor
		{
			get => _anchor; set
			{
				_anchor = value;
				Moved?.Invoke();
			}
		}
		Anchor _anchor;
		public bool IsEnabled
		{
			get => _isEnabled; set
			{
				_isEnabled = value;
				if (value)
					Enabled?.Invoke();
				else
					Disabled?.Invoke();
			}
		}
		protected bool _isEnabled;

		public TUIObjectPartType PartType { get; protected set; }

		public virtual int Width
		{
			get => _width;
			set
			{
				_width = value;
				Resized?.Invoke();
			}
		}
		protected int _width;
		public virtual int Height
		{
			get => _height;
			set
			{
				_height = value;
				Resized?.Invoke();
			}
		}
		protected int _height;

		public Color ForeColor { get; set; }
		public Color BackColor { get; set; }

		public Color ClearingColor { get;private set; }

		protected AbstractTUIObjectPart(string name, Anchor? anchor, int width, int height, Color foreColor, Color backColor,Color clearingColor, bool isEnabled, TUIObjectPartType partType)
		{
			Name = name;
			_anchor = anchor ?? new();
			_isEnabled = isEnabled;
			PartType = partType;
			_width = width;
			_height = height;
			ForeColor = foreColor;
			BackColor = backColor;
			ClearingColor = clearingColor;
		}


		/// <summary>
		/// Draws part
		/// </summary>
		/// <param name="parentAnchor">Parent anchor to offset from</param>
		public virtual bool Draw(Anchor parentAnchor)
		{
			UseColors();
			return SetCursor(parentAnchor.Left, parentAnchor.Top);
		}

		public virtual bool Clear(Anchor parentAnchor)
		{
			if (ClearingColor == Color.Black)
				Console.BackgroundColor = ConsoleColor.Black;
			else
			UseColors(ClearingColor,ClearingColor);

			if (!SetCursor(parentAnchor.Left, parentAnchor.Top))
				return false;

			for (int i = 0; i < Height; i++)
			{
				WriteText(new string(' ', Width),new(parentAnchor.Left+Anchor.Left,parentAnchor.Top+Anchor.Top+i));
			}

			return true;
		}

		public bool SetCursor(int left, int top)
		{
			Anchor pos = new(left, top);
			if (pos.Left < 0 || pos.Left >= TUIManager.BufferWidth)
				return false;
			if (pos.Top < 0 || pos.Top >= TUIManager.BufferHeight)
				return false;

			Console.SetCursorPosition(pos.Left, pos.Top);

			return true;
		}

		public void WriteText(string text,Anchor position)
		{
			for (int i = 0; i < text?.Length; i++)
			{
				if (!SetCursor(position.Left + i, position.Top))
					break;

				Console.Write(text[i]);
			}
		}

		public virtual void UseColors()
		{
			//48 - backgr
			Console.Write($"\u001b[48;2;{BackColor.R};{BackColor.G};{BackColor.B};38;2;{ForeColor.R};{ForeColor.G};{ForeColor.B}m");
		}
		public void UseColors(Color colorFore, Color colorBack)
		{
			Console.Write($"\u001b[48;2;{colorBack.R};{colorBack.G};{colorBack.B};38;2;{colorFore.R};{colorFore.G};{colorFore.B}m");
		}

	

		public void ResetColors()
		{
			Console.ResetColor();
		}

		protected void InvokeResized()
		{
			Resized?.Invoke();
		}
	}
}

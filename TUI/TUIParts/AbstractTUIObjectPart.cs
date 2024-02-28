using TUI.Structs;

namespace TUI.TUIParts
{
	public abstract class AbstractTUIObjectPart : ITUIObjectPart
	{
		public event Action? Resized;
		public event Action? Enabled;
		public event Action? Disabled;
		public event Action? Moved;

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

		public ConsoleColor ForeColor { get; set; }
		public ConsoleColor BackColor { get; set; }

		protected AbstractTUIObjectPart(string name, Anchor? anchor, int width, int height, ConsoleColor foreColor, ConsoleColor backColor, bool isEnabled, TUIObjectPartType partType)
		{
			Name = name;
			_anchor = anchor ?? new();
			_isEnabled = isEnabled;
			PartType = partType;
			_width = width;
			_height = height;
			ForeColor = foreColor;
			BackColor = backColor;
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
			if (!SetCursor(parentAnchor.Left, parentAnchor.Top))
				return false;

			for (int i = 0; i < Height; i++)
			{
				Console.Write(new string(' ', Width));
			}

			return true;
		}

		public bool SetCursor(int left, int top)
		{
			Anchor pos = new(left, top);
			if (pos.Left < 0 || pos.Left >= Console.BufferWidth)
				return false;
			if (pos.Top < 0 || pos.Top >= Console.BufferHeight)
				return false;

			Console.SetCursorPosition(pos.Left, pos.Top);

			return true;
		}
		public virtual void UseColors()
		{
			Console.ForegroundColor = ForeColor;
			Console.BackgroundColor = BackColor;
		}
	}
}

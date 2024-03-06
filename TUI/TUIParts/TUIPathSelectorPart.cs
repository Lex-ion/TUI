using TUI.Structs;

namespace TUI.TUIParts
{
	internal class TUIPathSelectorPart : TUITextBoxPart
	{
		public new int Height
		{
			get => _height; set
			{
				_height = value;
				InvokeResized();
			}
		}
		new int _height;

		DirectoryInfo? _CurrentDirectory;
		DirectoryInfo[]? _subDirs => _CurrentDirectory?.GetDirectories("*",new EnumerationOptions() { AttributesToSkip=FileAttributes.System|FileAttributes.Hidden});
		DriveInfo[] _drives => DriveInfo.GetDrives().Where(d=>d.IsReady).ToArray();
		string? _previousText;

		int _countOfItems
		{
			get
			{
				return _subDirs?.Length-1 ?? _drives?.Length-1 ?? 0;
			}
		}
		bool _displayedDirs => _subDirs is not null;
		int _selectedIndex;
		int _displayoffset;

		public TUIPathSelectorPart(string name, Anchor? anchor, int width, int height, string text, ConsoleColor foreColor, ConsoleColor backColor, ConsoleColor onCursorColorFore, ConsoleColor onCursorColorBack, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, 1, text,0, foreColor, backColor, onCursorColorFore, onCursorColorBack, isEnabled, partType)
		{
			_height = height - 1;
		}



		public override bool Draw(Anchor parentAnchor)
		{
			ParentAnchor = parentAnchor;
			if (!base.Draw(parentAnchor))
				return false;

			return true;
		}

		public override void Interact()
		{

			_CurrentDirectory = Text is not null&&Text.Length>0 && new DirectoryInfo(Text).Exists ? new DirectoryInfo(Text) : null ;
			_previousText = _text;
			ConsoleKeyInfo info;

			Write(1);

			do
			{

				info = TUIManager.GetKey();
				ProcessKey(info);

			} while (info.KeyChar != '\r'&&info.Key!=ConsoleKey.Escape);
			Clear();
		}

		void ProcessKey(ConsoleKeyInfo info)
		{
			#region List
			

			if (_selectedIndex > _countOfItems)
				_selectedIndex = _countOfItems - 1;
			if (info.Key == ConsoleKey.UpArrow && _selectedIndex > 0)
			{
				_selectedIndex--;

				if (_selectedIndex == _displayoffset && _selectedIndex >  0)
					_displayoffset--;

			}
			else if (info.Key == ConsoleKey.DownArrow && _selectedIndex < _countOfItems)
			{
				_selectedIndex++;

				if (_selectedIndex+1 == _displayoffset + Height)
					_displayoffset++;
			}
			_selectedIndex = _selectedIndex < 0 ? 0 : _selectedIndex;

			switch (info.Key)
			{
				case ConsoleKey.RightArrow:
					if (_subDirs is not null && _subDirs?.Length == 0)
						break;
					_text = _subDirs?[_selectedIndex].FullName ?? _drives[_selectedIndex].Name;
					_CurrentDirectory = new(_subDirs?[_selectedIndex].FullName ?? _drives[_selectedIndex].Name);

					_selectedIndex = 0;
					_displayoffset = 0;
					break;

				case ConsoleKey.LeftArrow:

					_displayoffset = 0;
					_selectedIndex = 0;
					if (_CurrentDirectory?.Parent is null)
					{
						_text = "";
						_CurrentDirectory = null;
						break;
					}

					_text = _CurrentDirectory.Parent.ToString();
					_CurrentDirectory = _CurrentDirectory.Parent;
					break;
			}
			
			#endregion

			#region TextInput

			if (info.Key == ConsoleKey.Enter)
			{
				
				Text = _text!=null&& _text.Length > 0 && new DirectoryInfo(_text).Exists ? _text : "";

				if (  !Directory.Exists(Text))
					TUIWarningMessage.Show("Zadaná cesta není validní!","CHYBA");

				InvokeSubmitted();
				return;
			}
			else if (info.Key == ConsoleKey.Escape)
			{
				_text = _previousText;
				InvokeCanceled();
				return;
			}
			else if (info.Key == ConsoleKey.Backspace&&_text.Length>0)
			{
				_text = _text.Remove(_text.Length - 1);
			}
			else if (!char.IsControl(info.KeyChar))
				_text += info.KeyChar;
			if (info.Key == ConsoleKey.UpArrow || info.Key == ConsoleKey.DownArrow || info.Key == ConsoleKey.LeftArrow || info.Key == ConsoleKey.RightArrow)
				Write();
			else
			{
				UseInteractColor();
				WriteText();
			}

			#endregion
		}

		void Write(int delay=0)
		{
			UseInteractColor();
			WriteText();
			UseColors();
			for (int i = 0; i < Height; i++)
			{
				if (!SetCursor(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + 1 + i))
					break;
				if (i + _displayoffset > _countOfItems)
				{
					Console.Write(new String(' ', Width));
					continue;
				}

				string displayText = _subDirs?[i + _displayoffset].Name.ToString() ?? _drives[i + _displayoffset].ToString();


				if (displayText.Length > Width)
					displayText = displayText.Remove(Width);
				else if (displayText.Length < Width)
					displayText = displayText.PadRight(Width, ' ');

				if (i == _selectedIndex - _displayoffset)
					Console.BackgroundColor = ConsoleColor.Green;
				else Console.BackgroundColor = ConsoleColor.DarkYellow;

				Console.Write(displayText);
				Thread.Sleep(delay);

			}

		}
		void Clear()
		{
			Console.BackgroundColor=ConsoleColor.Black;
            for (int i = Height - 1; i >= 0; i--)
            {
				if (!SetCursor(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + 1 + i))
					break;
				Console.Write(new String(' ', Width));
				Thread.Sleep(1);
			}
            //for (int i = 0; i < Height; i++)
			//{
			//	if (!SetCursor(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + 1 + i))
			//		break;
			//		Console.Write(new String(' ', Width));		
			//
			//}
		}
	}
	
}

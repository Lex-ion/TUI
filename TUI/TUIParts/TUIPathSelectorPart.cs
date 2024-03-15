using System.Drawing;
using TUI.Menus;
using TUI.Menus.PopUps;
using TUI.Structs;

namespace TUI.TUIParts
{
    public class TUIPathSelectorPart : TUITextBoxPart
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

		protected DirectoryInfo? _CurrentDirectory;
		protected DirectoryInfo[]? _subDirs => _CurrentDirectory?.GetDirectories("*",new EnumerationOptions() { AttributesToSkip=FileAttributes.System|FileAttributes.Hidden});
		protected DriveInfo[] _drives => DriveInfo.GetDrives().Where(d=>d.IsReady).ToArray();
		string? _previousText;

		protected virtual int _countOfItems
		{
			get
			{
				return _subDirs?.Length-1 ?? _drives?.Length-1 ?? 0;
			}
		}

		protected virtual string[]? Names=>_subDirs?.Select(s=>s.Name).ToArray()??null;

		bool _displayedDirs => _subDirs is not null;
		protected int _selectedIndex;
		int _displayoffset;

		public Color SelectedColor { get; protected set; }

		public TUIPathSelectorPart(string name, Anchor? anchor, int width, int height, string text, int maxChars, Color foreColor, Color backColor, Color onCursorColorFore, Color onCursorColorBack,Color clearingColor, bool isEnabled, TUIObjectPartType partType, char freeSpaceChar, char secretChar, Color writingColorFore, Color writingColorBack,Color selectedColor) 
			: base(name, anchor, width, 1, text, maxChars, foreColor, backColor, onCursorColorFore, onCursorColorBack,clearingColor, isEnabled, partType, freeSpaceChar, secretChar, writingColorFore, writingColorBack)
		{
			_height = height - 1;
			SelectedColor = selectedColor;
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
			TUIManager.RedrawCurrent();
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

			DiveIn(info);
			
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

		protected virtual void DiveIn(ConsoleKeyInfo info)
		{
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
		}

		protected virtual void Write(int delay=0)
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

				string displayText = Names?[i + _displayoffset] ?? _drives[i + _displayoffset].ToString();


				if (displayText.Length > Width)
					displayText = displayText.Remove(Width);
				else if (displayText.Length < Width)
					displayText = displayText.PadRight(Width, ' ');

				if (i == _selectedIndex - _displayoffset)
					UseColors(WritingColorFore, SelectedColor);
				else UseColors(WritingColorFore, WritingColorBack);

				Console.Write(displayText);
				Thread.Sleep(delay);

			}

		}


		void Clear()
		{

			if (ClearingColor == Color.Black)
				Console.BackgroundColor = ConsoleColor.Black;
			else
				UseColors(ClearingColor, ClearingColor);

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

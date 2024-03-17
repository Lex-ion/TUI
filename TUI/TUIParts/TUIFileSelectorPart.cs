using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
	public class TUIFileSelectorPart : TUIPathSelectorPart
	{
		Regex Regex {  get; set; }

		public TUIFileSelectorPart(string name,Regex fileNameRegex, Anchor? anchor, int width, int height, string text, int maxChars, Color foreColor, Color backColor, Color onCursorColorFore, Color onCursorColorBack, Color clearingColor, bool isEnabled, TUIObjectPartType partType, char freeSpaceChar, char secretChar, Color writingColorFore, Color writingColorBack, Color selectedColor) : base(name, anchor, width, height, text, maxChars, foreColor, backColor, onCursorColorFore, onCursorColorBack, clearingColor, isEnabled, partType, freeSpaceChar, secretChar, writingColorFore, writingColorBack, selectedColor)
		{
			Regex= fileNameRegex;
		}

		protected override string[]? Names => (_subDirs?.Select(s => s.Name)??new string[0]).Concat((files?.Select(f => f.Name).Where(s=>Regex.IsMatch(s))??new string[0])??new string[0]).ToArray().Length>0?
			(_subDirs?.Select(s => s.Name) ?? new string[0]).Concat((files?.Select(f => f.Name).Where(s => Regex.IsMatch(s)) ?? new string[0])).ToArray()
			: null;

		FileInfo[]? files => _CurrentDirectory?.GetFiles()??null;

		protected override int _countOfItems => Names?.Length - 1 ?? _drives.Length - 1;

		protected override void DiveIn(ConsoleKeyInfo info)
		{
			if (info.Key==ConsoleKey.LeftArrow ||_CurrentDirectory is null || (_subDirs?.Any(s => s.Name == Names![_selectedIndex])??false))
			base.DiveIn(info);
			else if (info.Key==ConsoleKey.RightArrow&&Names is not null)
			{
				_text = files!.Where(f => f.Name == Names![_selectedIndex]).FirstOrDefault()!.FullName;
			}
		}
		protected override bool ValidPath()
		{
			return File.Exists(_text);
		}
	}
}

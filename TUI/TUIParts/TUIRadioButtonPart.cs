using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
	public class TUIRadioButtonPart : AbstractTUIInteractivePart, ITUILabel
	{
		public event Action? ValueChanged;

		public readonly int RadioFamilyID;
		public bool RadioTicked
		{
			get => _radioTicked; set
			{
				RadioTicked = value;
				ValueChanged?.Invoke();
			}
		}
		bool _radioTicked;
		public TUIRadioButtonPart(string name, int radioFamily, string content, Anchor? anchor, int width, int height, ConsoleColor foreColor, ConsoleColor backColor, ConsoleColor onCursorColorFore, ConsoleColor onCursorColorBack, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor, onCursorColorFore, onCursorColorBack, isEnabled, partType)
		{
			RadioFamilyID = radioFamily;
			_content=content;
			RadioFamily.RegisterRadio(radioFamily, this);
		}

		public event Action? TextChanged;
		public string? Content { get => _content; set
			{
				_content = value;
				TextChanged?.Invoke();
			}	}
		string? _content;

		public override bool Draw(Anchor parentAnchor)
		{
			if (!base.Draw(parentAnchor))
				return false;

			if (!SetCursor(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top))
				return false;

			Console.Write((RadioTicked ? "◙" : "○")+(Content?.Length>0?" "+Content:"" ??""));
			return true;
		}

	}

	public class RadioFamily
	{
		static Dictionary<int, List<TUIRadioButtonPart>> Families = new();
		public static void RegisterRadio(int family, TUIRadioButtonPart radio)
		{
			radio.ValueChanged += () => { Switched(radio); };

		}

		static void Switched(TUIRadioButtonPart radio)
		{
			if (!radio.RadioTicked)
				return;
			foreach (TUIRadioButtonPart rbp in Families[radio.RadioFamilyID])
			{
				if (rbp != radio)
					rbp.RadioTicked = false;
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
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
				_radioTicked = value;
				ValueChanged?.Invoke();
			}
		}
		bool _radioTicked;
		public TUIRadioButtonPart(string name, int radioFamily, string content,bool isTicked, Anchor? anchor, Color foreColor, Color backColor, Color onCursorColorFore, Color onCursorColorBack,Color clearingColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, content?.Length+2??1, 1, foreColor, backColor, onCursorColorFore, onCursorColorBack,clearingColor, isEnabled, partType)
		{
			RadioFamilyID = radioFamily;
			_content=content;
			_radioTicked = isTicked;
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

			WriteText((RadioTicked ? "@" : "o") + (Content?.Length > 0 ? " " + Content : "" ?? ""),new(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top));

			return true;
		}

		public override void Interact()
		{
			if (!IsSelected)
				return;

			base.Interact();
			RadioTicked = true;
		}

		protected class RadioFamily
		{
			static Dictionary<int, List<TUIRadioButtonPart>> Families = new();
			public static void RegisterRadio(int family, TUIRadioButtonPart radio)
			{
				radio.ValueChanged += () => { Switched(radio); };

				if (!Families.Keys.Any(f => f == family))
				{
					Families.Add(family, new List<TUIRadioButtonPart>());
					radio._radioTicked = true;
				}
				else if (radio._radioTicked) {
					Families[family].ForEach(r=>r._radioTicked=false);
				}

				Families[family].Add(radio);

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

	
}

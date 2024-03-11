using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
    public class TUIProgressBarPart : AbstractTUIObjectPart
    {
        public event Action? ValueChanged;
        public event Action? MaximumChanged;
        public event Action? MinimumChanged;

        public int Value
        {
            get => _value; set
            {
                if (value > Maximum || value < Minimum)
                    throw new IndexOutOfRangeException();

                _value = value;
                ValueChanged?.Invoke();
            }

        }
        int _value;
        public int Maximum
        {
            get => _maximum; set
            {
                if (value <= Minimum || value < Value)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _maximum = value;
                MaximumChanged?.Invoke();
            }
        }
        int _maximum;
        public int Minimum
        {
            get => _minimum; set
            {
                if (value < 0 || value >= Maximum || value > Value)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _minimum = value;
                MinimumChanged?.Invoke();
            }
        }
        int _minimum;
        public TUIProgressBarPart(string name, Anchor? anchor, int width, int height, int value, int maximum, int minimum, Color foreColor, Color backColor,Color clearingColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor,clearingColor, isEnabled, partType)
        {
            Value = value;
            Maximum = maximum;
            Minimum = minimum;
        }

        public override bool Draw(Anchor parentAnchor)
        {
            if (!base.Draw(parentAnchor))
                return false;

            int percentage = (int)100.0 * (Value - Minimum) / (Maximum - Minimum);
            int segments = (int)Math.Floor(Width * (percentage / (float)100));
            for (int i = 0; i < Height; i++)
            {
                if (!SetCursor(parentAnchor.Left + Anchor.Left, parentAnchor.Top + Anchor.Top + i))
                    return false;
                UseColors(ForeColor, BackColor);
                WriteText(new string('█', segments).PadRight(Width, '░'),new(parentAnchor.Left + Anchor.Left, parentAnchor.Top + Anchor.Top + i));
			}
            return true;
        }

    }
}

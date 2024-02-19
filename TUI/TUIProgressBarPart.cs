using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    public class TUIProgressBarPart : AbstractTUIObjectPart, ITUIColorsSet
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
                if (value <= Minimum||value<Value)
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


        public bool BackGroundSet => throw new NotImplementedException();

        public bool ForeGroundSet => throw new NotImplementedException();

        public TUIProgressBarPart(string name, Anchor? anchor, int width, int height, int value = 0, int maximum = 100, int minimum = 0)
        {
            Name=name;
            Anchor = anchor ?? new();
            Width = width;
            Height = height;
            Value = value;
            Maximum = maximum;
            Minimum = minimum;
        }

        public override void Draw(Anchor parentAnchor)
        {
            if (!SetCursor(parentAnchor.Left + Anchor.Left, parentAnchor.Top + Anchor.Top))
                return;

            int percentage = (int)100.0 * (Value - Minimum) / (Maximum - Minimum);
            int segments =(int)Math.Floor(Width * (percentage / (float)100));
            for (int i = 0; i < Height; i++)
            {
                if (!SetCursor(parentAnchor.Left + Anchor.Left, parentAnchor.Top + Anchor.Top+i))
                    return;
                Console.Write(new String('█', segments).PadRight(Width, '░')) ;
            }
        }

        public void SetBackGroundColor(ConsoleColor backGround)
        {
            throw new NotImplementedException();
        }

        public void SetColors(ConsoleColor foreGround, ConsoleColor backGround)
        {            
            throw new NotImplementedException();
        }

        public void SetForeGroundColor(ConsoleColor foreGround)
        {
            throw new NotImplementedException();
        }
    }
}

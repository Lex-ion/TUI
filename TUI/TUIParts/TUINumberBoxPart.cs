using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;
using static System.Net.Mime.MediaTypeNames;

namespace TUI.TUIParts
{
    public class TUINumberBoxPart : AbstractTUIInteractivePart
    {
        public event Action? ValueChanged;
        public event Action? Submited;
        public event Action? Canceled;

        public event Action? MaximumChanged;
        public event Action? MinimumChanged;

        public int Value
        {
            get => _value; set
            {
                _value = value;
                ValueChanged?.Invoke();
            }
        }
        int _value;

        public int Maximum
        {
            get => _maximum; set
            {
                _maximum = value;
                MaximumChanged?.Invoke();
            }
        }
        public int Minimum
        {
            get => _minimum; set
            {
                _minimum = value;
                MinimumChanged?.Invoke();
            }
        }
        int _maximum;
        int _minimum;


        Anchor _parentAnchor;

        public TUINumberBoxPart(string name, Anchor? anchor, int width, int value, int max, int min, ConsoleColor foreColor, ConsoleColor backColor, ConsoleColor onCursorColorFore, ConsoleColor onCursorColorBack, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, 1, foreColor, backColor, onCursorColorFore, onCursorColorBack, isEnabled, partType)
        {
            _value = value;
            _minimum = min;
            _maximum = max;
        }

        public override bool Draw(Anchor parentAnchor)
        {
            _parentAnchor = parentAnchor;
            if (!base.Draw(parentAnchor))
                return false;

            if (!SetCursor(parentAnchor.Left + Anchor.Left, parentAnchor.Top + Anchor.Top))
                return false;
            Write(Value);
                
            return true;
        }
        public override void Interact()
        {
            base.Interact();			

			int currentNumber = Value;

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Write(currentNumber);

            ConsoleKeyInfo input = TUIManager.GetKey();
            try
            {


            while (input.KeyChar != '\r')
            {
                if (input.KeyChar == 27)
                {
                    Canceled?.Invoke();
                    return;
                }
                else if (input.KeyChar == '\b'  )
                {
                    if (currentNumber.ToString().Length > 1&&currentNumber>0)
                        currentNumber = Convert.ToInt32(currentNumber.ToString().Remove(currentNumber.ToString().Length - 1));
                    else currentNumber = 0;
                }
                else if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.RightArrow)
                {
                    currentNumber++;
                }
                else if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.LeftArrow)
                {
                    currentNumber--;
                }
                else if (char.IsNumber(input.KeyChar))
                {
                    currentNumber = Convert.ToInt32(currentNumber.ToString() + input.KeyChar);
                }
                else if (input.KeyChar == '-')
                {
                    currentNumber *= -1;
                }
                if (currentNumber > Maximum)
                    currentNumber = Maximum;
                else if (currentNumber < Minimum)
                    currentNumber = Minimum;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Write(currentNumber);
				 input = TUIManager.GetKey();
			}
            Value = currentNumber;
            Submited?.Invoke();
            }
            catch (Exception ex)
            {
                TUIWarningMessage.Show(ex.Message);
                Canceled?.Invoke();
            }

        }

        void Write(int num)
        {
			WriteText(num.ToString().PadLeft(Width * Height, '_')[^(Width * Height)..], new(_parentAnchor.Left + Anchor.Left, _parentAnchor.Top + Anchor.Top));

		}
	}
}

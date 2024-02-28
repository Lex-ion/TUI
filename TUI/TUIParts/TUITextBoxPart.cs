using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
    public class TUITextBoxPart : AbstractTUIInteractivePart
    {
		public event Action? TextChanged;
        public event Action? Submited;
        public event Action? Canceled;

		public string Text { get => _text; set { 
            _text = value;
                TextChanged?.Invoke();
            } }
        string _text;


        public Anchor ParentAnchor { get; set; }

        public bool HiddenChars { get; set; }


        public TUITextBoxPart(string name, Anchor? anchor, int width, int height, string text, ConsoleColor foreColor, ConsoleColor backColor, ConsoleColor onCursorColorFore, ConsoleColor onCursorColorBack, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, width, height, foreColor, backColor, onCursorColorFore, onCursorColorBack, isEnabled, partType)
        {
            _text = text ?? "";
        }

        public override bool Draw(Anchor parentAnchor)
        {
            ParentAnchor = parentAnchor;
            if (!base.Draw(parentAnchor))
                return false;

            if (!SetCursor(parentAnchor.Left + Anchor.Left, parentAnchor.Top + Anchor.Top))
                return false;

            WriteText();
            return true;
        }

        public override void Interact()
        {
            base.Interact();

            if (!IsSelected || !IsEnabled)
                return;


            Console.BackgroundColor = ConsoleColor.DarkYellow;
            WriteText();
            GetUserInput();
            Console.CursorVisible = false;
        }

        private void WriteText(string? text=null)
        {
            text??= Text;

            for (int i = 0; i < Height; i++)
            {
                if (SetCursor(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + i))
                    WriteText(HiddenChars ? new string('*', text.Length).PadRight(Width * Height, '_')[^(Width * Height)..][(Width * i)..(Width * (i + 1))] : text.PadRight(Width * Height, '_')[^(Width * Height)..][(Width * i)..(Width * (i + 1))],new(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + i));
            }
        }
        private void GetUserInput()
        {
            string currentText= Text;
            char userInput = Console.ReadKey(true).KeyChar;
            while (userInput != '\r')
            {
                if (userInput == 27)
                {
                    Canceled?.Invoke();
					return;
				}
               
                if (userInput == '\b')
                {

                    if (currentText.Length == 0)
                    {
                        userInput = Console.ReadKey(true).KeyChar;
                        continue;
                    }



                    currentText = currentText.Remove(currentText.Length - 1);
                    Write();
                    userInput = Console.ReadKey(true).KeyChar;
                    continue;
                }
				if (!char.IsControl(userInput))
				currentText += userInput;

                Write();


                userInput = Console.ReadKey(true).KeyChar;
            }
            Text = currentText;
            Submited?.Invoke();

            void Write()
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                WriteText(currentText);
            }
        }
    }
}

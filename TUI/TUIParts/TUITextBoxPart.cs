using System;
using System.Collections.Generic;
using System.Drawing;
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

		public string Text { get => _text??""; set { 
            _text = value;
                TextChanged?.Invoke();
            } }
        protected string? _text;


        public Anchor ParentAnchor { get; set; }

        public bool HiddenChars { get; set; }

        public int MaxChars { get; set; }

        public char FreeSpaceChar { get;protected set; }
        public char SecretChar {  get;protected set; }

		public Color WritingColorFore { get; set; }
		public Color WritingColorBack { get; set; }

		public TUITextBoxPart(string name, Anchor? anchor, int width, int height, string text,int maxChars, Color foreColor, Color backColor, Color onCursorColorFore, Color onCursorColorBack,Color clearingColor, bool isEnabled, TUIObjectPartType partType,char freeSpaceChar, char secretChar, Color writingColorFore, Color writingColorBack) 
            : base(name, anchor, width, height, foreColor, backColor, onCursorColorFore, onCursorColorBack,clearingColor, isEnabled, partType)
        {MaxChars=maxChars;
            _text = text ?? "";
            SecretChar=secretChar;
            FreeSpaceChar=freeSpaceChar;
			WritingColorFore = writingColorFore;
			WritingColorBack = writingColorBack;
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


         UseInteractColor();
            WriteText();
            GetUserInput();
            Console.CursorVisible = false;
        }
        protected void UseInteractColor()
        {
            UseColors(WritingColorFore,WritingColorBack);
		}

        protected void WriteText(string? text=null)
        {
            text??= Text;

            for (int i = 0; i < Height; i++)
            {
                if (SetCursor(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + i))
                    WriteText(HiddenChars ? new string(SecretChar, text.Length).PadRight(Width * Height, FreeSpaceChar)[^(Width * Height)..][(Width * i)..(Width * (i + 1))] : text.PadRight(Width * Height, FreeSpaceChar)[^(Width * Height)..][(Width * i)..(Width * (i + 1))],new(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + i));
            }
        }
        private void GetUserInput()
        {
            string currentText= Text;
            char userInput = TUIManager.GetKey().KeyChar;
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
                        userInput = TUIManager.GetKey().KeyChar;
                        continue;
                    }

                    currentText = currentText.Remove(currentText.Length - 1);
                    Write();
                    userInput = TUIManager.GetKey().KeyChar;
                    continue;
                }

                if(MaxChars>0||_text?.Length <= MaxChars)
				if (!char.IsControl(userInput))
				currentText += userInput;

                Write();


                userInput = TUIManager.GetKey().KeyChar;
            }
            Text = currentText;
            Submited?.Invoke();

            void Write()
			{
				UseColors(WritingColorFore, WritingColorBack);
				WriteText(currentText);
            }
        }

        protected void InvokeSubmitted() => Submited?.Invoke();
        protected void InvokeCanceled() => Canceled?.Invoke();
	}
}

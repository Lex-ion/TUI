using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    public class TUITextBoxPart : AbstractTUIInteractivePart
    {
        public string Text { get; private set; }


        public Anchor ParentAnchor { get; set; }

        public bool HiddenChars { get; set; }
        public bool IsEditable { get; set; }

        public TUITextBoxPart()
        {
            Text = "";
            IsEditable = true;
        }



        public override void Draw(Anchor parentAnchor)
        {
            ParentAnchor = parentAnchor;

            if (!SetCursor(parentAnchor.Left + Anchor.Left, parentAnchor.Top + Anchor.Top))
                return;

            if (!IsSelected)
            {
                Console.ForegroundColor = ForeGround;
                Console.BackgroundColor = BackGround;
            }
            else
            {
                Console.ForegroundColor = OnCursorColorFore;
                Console.BackgroundColor = OnCursorColorBack;
            }
            WriteText();
        }

        public override void Interact()
        {
            base.Interact();

            if (!IsSelected || !IsEditable)
                return;


            Console.BackgroundColor = ConsoleColor.DarkYellow;
            WriteText();

            /*  if (Text.Length > Width)
              {
                  string s = "";
                  for (int i = 0; i < Width; i++)
                      s += Text[Text.Length  - Width + i];
                  Console.Write(s);
              }
              else
              {

                  int padding = Width - Text.Length;
                  string s = "";
                  for (int i = 0; i < Text.Length ; i++)
                      s += Text[ i];
                  s += new string('_', padding);
                  Console.Write(s);
              }*/

            GetUserInput();
            Console.CursorVisible = false;
        }

        private void WriteText()
        {
            for (int i = 0; i < Height; i++)
            {
                if (SetCursor(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top + i))
                    Console.Write(HiddenChars ? new string('*', Text.Length).PadRight(Width * Height, '_')[^(Width * Height)..][(Width * i)..(Width * (i + 1))] : Text.PadRight(Width * Height, '_')[^(Width * Height)..][(Width * i)..(Width * (i + 1))]);
            }
        }
        private void GetUserInput()
        {

            char userInput = Console.ReadKey(true).KeyChar;
            while (userInput != '\r')
            {

                if (userInput == '\b')
                {

                    if (Text.Length == 0)
                    {
                        userInput = Console.ReadKey(true).KeyChar;
                        continue;
                    }



                    Text = Text.Remove(Text.Length - 1);
                    Write();
                    userInput = Console.ReadKey(true).KeyChar;
                    continue;
                }

                Text += userInput;

                Write();


                userInput = Console.ReadKey(true).KeyChar;
            }
            void Write()
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                WriteText();

                /*
                if (SetCursor(ParentAnchor.Left + Anchor.Left, ParentAnchor.Top + Anchor.Top))
                Console.Write(Text.PadRight(Width, '_')[^Width..]);*/


                /*
                if (Text.Length + 1 > Width)
                {
                    for (int i = 0; i < Width; i++)
                    {
                        SetCursor(ParentAnchor.Left+ Anchor.Left + i, ParentAnchor.Top+Anchor.Top);
                        Console.Write(Text[Text.Length - Width + i]);
                    }
                }
                else
                {
                    int padding = Width - Text.Length;
                    if (userInput != '\b')
                    {
                        SetCursor(ParentAnchor.Left + Anchor.Left + Text.Length - 1, ParentAnchor.Top + Anchor.Top);

                        Console.Write(userInput);
                    }
                    else
                        SetCursor(ParentAnchor.Left + Anchor.Left + Text.Length, ParentAnchor.Top+ Anchor.Top);
                    Console.Write(new String(' ', padding));
                }*/
            }
        }
    }
}

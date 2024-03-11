using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;
using static System.Net.Mime.MediaTypeNames;
using TUI.TUIParts.Builder;
using TUI.TUIParts;
using TUI.Defaults;
using System.Drawing;

namespace TUI.Menus.PopUps
{
    public static class TUIWarningMessage
    {
        static TUIObjectBuilder Builder = new(new TUIBuilderDefaults(Color.Black, Color.Yellow));
        static bool b;
        public static void Show(string message, string? title = null)
        {
            TUIManager.UpdateBuffers();

            int width = TUIManager.BufferWidth / 2;
            int height = TUIManager.BufferHeight / 2;


            int LineLength = TUILabelPart.PredictLineLenght(message, TUIManager.BufferWidth - 10);
            int LabelHeight = TUILabelPart.PredictHeight(message, TUIManager.BufferWidth - 10);

            TUIObject @object;
            Builder.Reset();
            @object = Builder
                .AddColorOverlay("OU", LineLength + 2, 1, Color.FromArgb(200, 200, 0), new(-LineLength / 2, -5 - LabelHeight / 2))
                .AddColorOverlay("OD", LineLength + 2, 1, Color.FromArgb(200, 200, 0), new(-LineLength / 2, LabelHeight / 2 + 6 + (LabelHeight / 2 > 0 ? -1 : 0)))
                .Build(new Anchor(width, height + 1));


            TUIMessageBox.Show(message, title, Color.Yellow, Color.Black, foo);

            @object.Clear();

            void foo()
            {

                TUIManager.UpdateBuffers();
                if (b)
                    @object.Draw();
                else
                    @object.Clear();


                Thread.Sleep(250);
                b = !b;
            }
        }
    }
}

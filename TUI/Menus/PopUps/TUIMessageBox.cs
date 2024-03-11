using TUI.TUIParts.Builder;
using TUI.TUIParts;
using TUI.Defaults;
using System.Drawing;
using TUI.Structs;
using static System.Net.Mime.MediaTypeNames;

namespace TUI.Menus.PopUps
{
    public static class TUIMessageBox
    {
        static TUIObjectBuilder builder = new TUIObjectBuilder();

        public static void Show(string text, string? title, Color backColor, Color foreColor, Action? idleAction = null)
        {

            TUIManager.UpdateBuffers();

            builder.Defaults = new(foreColor, backColor);

            bool focused = true;
            builder.Reset();
            int width = TUIManager.BufferWidth / 2;
            int height = TUIManager.BufferHeight / 2;
            TUIObject @object;

            int LineLength = TUILabelPart.PredictLineLenght(text, TUIManager.BufferWidth - 10);
            int LabelHeight = TUILabelPart.PredictHeight(text, TUIManager.BufferWidth - 10);

            builder
                .AddColorOverlay("O", LineLength + 3, LabelHeight + 6, backColor, new(-LineLength / 2 - 1, -LabelHeight / 2 - 2))
                .AddLabel("L0", text, new(-LineLength / 2 + 1, -LabelHeight / 2), TUIManager.BufferWidth - 10)
                .AddFrame("F", LineLength + 2, 5 + builder.Product.Parts["L0"].Height, new Anchor(-LineLength / 2 - 1, -LabelHeight / 2 - 2))
                .AddButton("B", "> OK <", new Anchor(-2, LabelHeight / 2 + (LabelHeight / 2 > 0 ? 2 : 3)));

            if (title != null)
                builder.AddLabel("L1", title, new(-LineLength / 2 + 1, -LabelHeight / 2 - 2));

            @object = builder.Build(new Anchor(width, height));

            @object.TUIInteractable!.IsSelected = true;
            @object.TUIInteractable.Interacted += Done;

            @object.Draw();

            while (focused)
            {
                if (idleAction != null)
                {
                    while (Console.KeyAvailable)
                        if (TUIManager.GetKey().Key == ConsoleKey.Enter)
                            @object.TUIInteractable!.Interact();

                    idleAction?.Invoke();
                }
                else
                {
                    if (TUIManager.GetKey().Key == ConsoleKey.Enter)
                        @object.TUIInteractable!.Interact();
                }

            }

            @object.Clear();

            void Done() => focused = false;
        }
    }
}

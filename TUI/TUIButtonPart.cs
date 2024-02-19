using TUI.Structs;

namespace TUI
{
    internal class TUIButtonPart : AbstractTUIInteractivePart, ITUILabel
    {

        private string? _content;

        /// <summary>
        /// Text of button
        /// </summary>
        public string? Content
        {
            get { return _content is null ? "" : _content; }
            set
            {
                _content = value;
                List<string>? lines = value?.Split('\n').ToList() ?? null;
                Width = lines?.Sum(x => x.Length) ?? 0;
                Height = lines?.Count ?? 0;

            }
        }
        /// <summary>
        /// OLD, use Interacted instead.
        /// </summary>
        public Action? Action { get; set; }


        public override void Draw(Anchor parentAnchor)
        {
            if (!SetCursor(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top))
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

            Console.Write(Content);
        }
        public override void Interact()
        {
            base.Interact();
            if (!IsSelected)
                return;
            Action?.Invoke();
        }



    }
}

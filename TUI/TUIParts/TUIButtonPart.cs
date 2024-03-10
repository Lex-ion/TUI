using System.Drawing;
using TUI.Structs;

namespace TUI.TUIParts
{
    internal class TUIButtonPart : AbstractTUIInteractivePart, ITUILabel
    {
		public event Action? TextChanged;

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
                TextChanged?.Invoke();
            }
        }

        public TUIButtonPart(string name, Anchor? anchor, string? content, Color foreColor, Color backColor, Color onCursorColorFore, Color onCursorColorBack, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, content?.Length ?? 0, 1, foreColor, backColor, onCursorColorFore, onCursorColorBack, isEnabled, partType)
        {
            _content = content;

        }

        public override bool Draw(Anchor parentAnchor)
        {
            if (!base.Draw(parentAnchor))
                return false;

            if (!SetCursor(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top))
                return false;

            WriteText(Content??"",new(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top));
            return true;
        }
    }
}

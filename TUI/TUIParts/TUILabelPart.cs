using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI.TUIParts
{
    public class TUILabelPart : AbstractTUIObjectPart, ITUILabel
    {
        public event Action? TextChanged;
        private string? _content;

        public TUILabelPart(string name, Anchor? anchor, string? content, ConsoleColor foreColor, ConsoleColor backColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, content?.Length ?? 0, 1, foreColor, backColor, isEnabled, partType)
        {
            _content = content;
        }

        /// <summary>
        /// Text of label
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



        public override bool Draw(Anchor parentAnchor)
        {
            if (!base.Draw(parentAnchor))
                return false;

            Anchor pos = new(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top);
            WriteText(Content??"", pos);
            
            return true;
        }

    }
}

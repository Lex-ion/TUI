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
        public static int PredictLineLenght(string text,int maxLineLength)
        {
          int height= maxLineLength > 0 ? text.Length / maxLineLength + 1 : 1;
		int	width = maxLineLength > 0 ? maxLineLength : text.Length;
            return height > 1 ? width : text.Length;
		}

        public event Action? TextChanged;
        private string? _content;
        public int MaxLineLength { get => _MaxLineLenght; set => _MaxLineLenght=value; }
        int _MaxLineLenght;

        public override int Height => MaxLineLength > 0 ? Content!.Length / MaxLineLength +1: 1;
        public override int Width => MaxLineLength > 0 ? MaxLineLength : Content!.Length;

        public int LineLenght => Height > 1 ? Width : Content!.Length;

		public TUILabelPart(string name, Anchor? anchor, string? content,int maxLineLength, ConsoleColor foreColor, ConsoleColor backColor, bool isEnabled, TUIObjectPartType partType) : base(name, anchor, content?.Length ?? 0, 1, foreColor, backColor, isEnabled, partType)
        {
            _MaxLineLenght = maxLineLength;
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

            for (int i = 0; i < Height; i++)
            {
				Anchor pos = new(Anchor.Left + parentAnchor.Left, Anchor.Top + parentAnchor.Top+i);

                WriteText(Content[(i*MaxLineLength)..((i+1)*MaxLineLength>Content.Length?Content.Length: (i + 1) * MaxLineLength)], pos);
			}
            
            return true;
        }

    }
}

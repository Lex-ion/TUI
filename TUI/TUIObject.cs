using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;
using TUI.TUIParts;

namespace TUI
{
    public class TUIObject
    {

        private Dictionary<string,ITUIObjectPart> _parts = new();

        public bool IsInteractable => TUIInteractable is not null;
        public ITUIInteractable? TUIInteractable { get; protected set; }

        public Dictionary<string,ITUIObjectPart>? Parts { get { return _parts; } }
        
        public Anchor Anchor { get; set; }

        public void Draw()
        {      foreach (KeyValuePair<string,ITUIObjectPart> pair in _parts!)
            {
                pair.Value.Draw(Anchor);
            }
        }

        public void Clear()
        {
			foreach (KeyValuePair<string, ITUIObjectPart> pair in _parts!)
			{
				pair.Value.Clear(Anchor);
			}
		}

        public void AddPart(ITUIObjectPart part)
        {
			

			if (part is ITUIInteractable)
            {
				if (IsInteractable)
					throw new Exception("There can be only one interactable part at same time in one object");
				TUIInteractable = (ITUIInteractable)part;
			}
                

            _parts.Add(part.Name,part);
        }

        public ITUIInteractable? GetInteractable()
        {            
            return TUIInteractable;
        }

        public ITUIObjectPart[]? GetParts<T>() where T : ITUIObjectPart
        {
            return Parts?.Values.Where(p => p is T).ToArray()??null;
        }
        public ITUIObjectPart? GetPart<T>() where T:ITUIObjectPart
        {
            return GetParts<T>()?.FirstOrDefault()??null;
        }
    }
}

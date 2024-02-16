﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

namespace TUI
{
    public class TUIObject
    {

        private Dictionary<string,ITUIObjectPart> _parts = new();

        public bool IsInteractable { get;protected set; }

        public Dictionary<string,ITUIObjectPart> Parts { get { return _parts; } }
        
        public Anchor Anchor { get; set; }

        public void Draw()
        {      foreach (KeyValuePair<string,ITUIObjectPart> pair in _parts)
            {
                pair.Value.Draw(Anchor);
            }
        }

        public void AddPart(ITUIObjectPart part)
        {
            if (part is ITUIInteractable)
                IsInteractable = true;

            _parts.Add(part.Name,part);
        }

        public ITUIInteractable GetInteractable()
        {            
            return (ITUIInteractable)Parts.Values.Where(p => p is ITUIInteractable).First();
        }

        public ITUIObjectPart[] GetParts<T>() where T : ITUIObjectPart
        {
            return Parts.Values.Where(p => p is T).ToArray();
        }
        public ITUIObjectPart GetPart<T>() where T:ITUIObjectPart
        {
            return GetParts<T>().First();
        }
    }
}
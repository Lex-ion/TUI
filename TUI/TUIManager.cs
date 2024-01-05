using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI
{
    public class TUIManager
    {
        public Dictionary<string,List<TUIObject>> Menus=new Dictionary<string,List<TUIObject>>();
        public string CurrentMenu { get; private set; }

        public void OpenMenu(string menuName)
        {
            Menus[menuName].ForEach(o => o.Draw());
        }

    }
}

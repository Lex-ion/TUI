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

        public static int BufferWidth { get; set; }
        public static int BufferHeight { get; set; }

        public void OpenMenu(string menuName)
        {
            Menus[menuName].ForEach(o => o.Draw());
        }

        public static void UpdateBuffers()
        {
            BufferWidth = Console.BufferWidth;
			BufferHeight = Console.BufferHeight;
            
        }
        public static ConsoleKeyInfo GetKey(bool updateBuffers = true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if(updateBuffers)
            UpdateBuffers();
            return key;
        }

    }
}

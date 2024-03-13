using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Menus;

namespace TUI
{
    public class TUIManager
    {
         static Dictionary<string, ITUIMenu> TUIMenus =new Dictionary<string, ITUIMenu>();
        public static ITUIMenu? CurrentMenu { get; private set; }

        public static int BufferWidth { get;private set; }
        public static int BufferHeight { get;private set; }

        public static void OpenMenu(string menuName)
        {           
           CurrentMenu=TUIMenus[menuName];
            CurrentMenu.Clear();
            CurrentMenu.Draw();
        }
        

        public static void RegisterMenu(string menuName, ITUIMenu menu)
        {
            TUIMenus.Add(menuName, menu);
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

        public static void Start(ITUIMenu menu)
        {
            CurrentMenu = menu;
            CurrentMenu.Clear();

            while
                (true)
            {
                CurrentMenu.Draw();
                CurrentMenu.HandleInput(GetKey());
            }
        }

        public static void RedrawCurrent()
        {
            if (CurrentMenu is null)
                return;

            CurrentMenu.Clear();
            CurrentMenu.Draw();
        }

    }
}

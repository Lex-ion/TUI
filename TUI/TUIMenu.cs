using TUI.Structs;
using TUI.TUIParts;

namespace TUI
{
    public class TUIMenu
    {
        public Dictionary<string,TUIObject> Objects = new ();
        public List<TUIObject> Interactables { get => Objects.Values.Where(o=>o.IsInteractable).ToList(); }   
        public TUIObjectBuilder ObjectBuilder { get; set; }

        int previousWidth;
        int previousHeigth;

        public TUIMenu(ObjectBuilderDefaults defaults)
        {
            ObjectBuilder = new(Objects,defaults);
            previousHeigth = Console.WindowHeight;
            previousWidth = Console.WindowWidth;
        }
        public void Prepare()
        {
            Interactables.Clear();
            if (Interactables.Any())
            {
                Interactables.First().TUIInteractable.IsSelected = true;
            }
        }

        public void DrawMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            if(previousWidth!=Console.WindowWidth||previousHeigth!=Console.WindowHeight)
            {
                Console.Clear();
            }
            else
            {


			foreach (KeyValuePair<string, TUIObject> obj in Objects)
			{
				obj.Value.Clear(); //issue with resize of console
			}
            }

			foreach (KeyValuePair<string, TUIObject> obj in Objects)
            {
                obj.Value.Draw();
            }

			previousHeigth = Console.WindowHeight;
			previousWidth = Console.WindowWidth;
		}

        public void ReadInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                Interactables.ForEach(i => i.TUIInteractable.Interact());               
            }
            else if (key == ConsoleKey.RightArrow)
            {
                int index = Interactables.IndexOf(Interactables.Where(i => i.TUIInteractable.IsSelected).First())+1;
                Interactables.Where(i => i.TUIInteractable.IsSelected).First().TUIInteractable.IsSelected = false;
                Interactables[index>Interactables.Count-1?0:index].TUIInteractable.IsSelected = true;
            }
        }

    }
}

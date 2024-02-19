using TUI.Structs;

namespace TUI
{
    public class TUIMenu
    {
        public Dictionary<string,TUIObject> Objects = new ();
        public List<ITUIInteractable> Interactables = new();        
        public TUIObjectBuilder ObjectBuilder { get; set; }
        public TUIMenu(ObjectBuilderDefaults defaults)
        {
            ObjectBuilder = new(Objects,defaults);
        }
        public void Prepare()
        {
            Interactables.Clear();
            Objects.Where(o => o.Value.Parts.Any(p => p.Value is ITUIInteractable)).ToList().ForEach(i => Interactables.Add(i.Value.GetInteractable()));
            if (Interactables.Any())
            {
                Interactables.First().IsSelected = true;
            }
        }

        public void DrawMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (KeyValuePair<string, TUIObject> obj in Objects)
            {
                obj.Value.Draw();
            }
        }

        public void ReadInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                Interactables.ForEach(i => i.Interact());               
            }
            else if (key == ConsoleKey.RightArrow)
            {
                int index = Interactables.IndexOf(Interactables.Where(i => i.IsSelected).First())+1;
                Interactables.Where(i => i.IsSelected).First().IsSelected = false;
                Interactables[index>Interactables.Count-1?0:index].IsSelected = true;
            }
        }

    }
}

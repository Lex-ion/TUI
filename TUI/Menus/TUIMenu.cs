using TUI.Defaults;
using TUI.Structs;
using TUI.TUIParts;
using TUI.TUIParts.Builder;

namespace TUI.Menus
{
    public class TUIMenu
    {
        public Dictionary<string, TUIObject> Objects = new();
        public List<TUIObject> Interactables { get => Objects.Values.Where(o => o.IsInteractable).ToList(); }
        public TUIObjectBuilder ObjectBuilder { get; set; }

        int previousWidth;
        int previousHeigth;

        int selectedInteractableIndex;
        TUIObject? selectedInteractable;

        public TUIMenu(TUIBuilderDefaults defaults)
        {
            ObjectBuilder = new(defaults, Objects);
            previousHeigth = Console.WindowHeight;
            previousWidth = Console.WindowWidth;
        }
        public void Prepare()
        {
            if (Interactables.Any())
            {
                selectedInteractable = Interactables.FirstOrDefault();
                selectedInteractable.TUIInteractable.IsSelected = true;
            }
        }

        public void DrawMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            if (previousWidth != Console.WindowWidth || previousHeigth != Console.WindowHeight)
            {
                Console.Clear();
            }


            TUIManager.UpdateBuffers();
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
                selectedInteractable.TUIInteractable?.Interact();
            }
            else if (key == ConsoleKey.RightArrow)
            {
                if (Interactables.Count == 0)
                    return;

                selectedInteractable.TUIInteractable.IsSelected = false;
                selectedInteractableIndex = (selectedInteractableIndex + 1) % Interactables.Count;
                selectedInteractable = Interactables[selectedInteractableIndex];
                selectedInteractable.TUIInteractable.IsSelected = true;

            }
            else if (key == ConsoleKey.LeftArrow)
            {
                if (Interactables.Count == 0)
                    return;

                selectedInteractable.TUIInteractable.IsSelected = false;
                selectedInteractableIndex = (selectedInteractableIndex - 1) % Interactables.Count;
                selectedInteractableIndex = selectedInteractableIndex < 0 ? Interactables.Count - 1 : selectedInteractableIndex;
                selectedInteractable = Interactables[selectedInteractableIndex];
                selectedInteractable.TUIInteractable.IsSelected = true;

            }
        }


    }
}

using TUI.Structs;
using TUI.TUIParts;


namespace TUI
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

            TUIMenu menu = new(new ObjectBuilderDefaults());
            //-----OLD
            menu.ObjectBuilder.AddButton("l", "Zkusit", Beeper);
            menu.ObjectBuilder.AddFrame("f", "tlačítko".Length, 1, new(-1, -1));
            menu.ObjectBuilder.AddFrame("f2", "Toto tlačítko pípá".Length + 2, 3, new(-2, -2));
            menu.ObjectBuilder.AddLabel("l3", "Toto tlačítko pípá", new(0, -2));
            menu.Objects.Add("b", menu.ObjectBuilder.Build(new Anchor(5, 5)));

            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddButton("b2", "Záhadná věc", Exit);
            menu.ObjectBuilder.AddLabel("l2", "Co asi dělá?", new(0, 1));
            menu.Objects.Add("b1", menu.ObjectBuilder.Build(new Anchor(35, 5)));
            //---NEW
            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder
                .AddLabel("adf", "asdfas")
                .AddFrame("f3", 30, 6, new(-5, -5))
                .Build("Test");

            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder
                .AddFrame("F1", 20, 3, new(-1, -1), new())
                .AddTextBox("T1", 20, 3)
                .Build("TB", new(40, 20));

            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddProgressBar("pb", null, 20, 3, 0,10)                
                .Build("PB", new(25, 25));

            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddRadioButton("Rb", 0, "První radio")
                .Build("RB0",new(5,0));

			menu.ObjectBuilder.Reset();
			menu.ObjectBuilder.AddRadioButton("Rb", 0, "Druhé radio")
				.Build("RB1", new(5, 1));

			menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddRadioButton("Rb", 0, "Třetí radio", true)
				.Build("RB2", new(5, 2)); 

            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddLabel("L","Lorem ipsum dál to neumím a asi ani nechci no. Takže asi tak. Tenhle text je fakt dlouhej!")
                .Build("LL",new(25,24
                ));
            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddPathSelector("ps", 35, 10)
                .Build("Ps",new(2,10));
            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddNumberBox("NB",5)
                .Build("NB",new(5,9));


			menu.Prepare();
            menu.DrawMenu();


            menu.Interactables[0].TUIInteractable.Interacted += CharChange;
            menu.Interactables[0].TUIInteractable.Interacted += ChangeBar;
            foreach (TUIObject item in menu.Interactables)
            {
                item.TUIInteractable.Interacted += test;
            }
            while (true)
            {
                menu.ReadInput(TUIManager.GetKey(false).Key);
                menu.DrawMenu();
            }


             void CharChange()
            {
                var tb = (menu.Objects.Values.Where(o => o.Parts.Any(p => p.Value is TUITextBoxPart)).First().Parts.Where(p => p.Value is TUITextBoxPart).First().Value as TUITextBoxPart);
               tb.HiddenChars = !tb.HiddenChars;
            }

            void ChangeBar()
            {
                TUIProgressBarPart pb = (TUIProgressBarPart)menu.Objects["PB"].Parts["pb"];
                pb.Value++;
            }

        }
        public static void test() {
            Random random = new Random();
            Console.Beep(random.Next(500, 2500), 500); }
        public static void Beeper()
        {
            Console.Beep(1200, 250);
        }

        
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
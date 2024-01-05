using TUI.Structs;


namespace TUI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            TUIMenu menu = new(new ObjectBuilderDefaults());
            //-----OLD
            menu.ObjectBuilder.AddButton("l", "Zkusit",Beeper);
            menu.ObjectBuilder.AddFrame("f", "tlačítko".Length, 1,new(-1,-1));
            menu.ObjectBuilder.AddFrame("f2", "Toto tlačítko pípá".Length + 2, 3, new(-2, -2));
            menu.ObjectBuilder.AddLabel("l3", "Toto tlačítko pípá",new(0,-2));
            menu.Objects.Add( "b",menu.ObjectBuilder.Build(new Anchor(5,5)));

            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder.AddButton("b2", "Záhadná věc", Exit);
            menu.ObjectBuilder.AddLabel("l2","Co asi dělá?",new(0,1));
            menu.Objects.Add("b1",menu.ObjectBuilder.Build(new Anchor(35,5)));
            //---NEW
            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder
                .AddLabel("adf", "asdfas")
                .AddFrame("f3", 30, 6,new(-5,-5))
                .Build("Test");

            menu.ObjectBuilder.Reset();
            menu.ObjectBuilder
                .AddFrame("F1", 1, 10, new(-1, -1),new())
                .AddTextBox("T1",1,10)
                .Build("TB",new(40, 20));

            menu.Prepare();
            menu.DrawMenu();


            menu.Interactables[0].Interacted += test;
            menu.Interactables[0].Interacted += test;
            menu.Interactables[0].Interacted += test;
            foreach (ITUIInteractable item in menu.Interactables)
            {
                item.Interacted += test;
            }
            while (true)
            {
                menu.ReadInput(Console.ReadKey(true).Key);
                menu.DrawMenu();
            }

/*

            TUIManager ui = new TUIManager();
            List<TUIObject> objs = new();

            TUIObjectBuilder b = new TUIObjectBuilder();
            b.AddLabel("mujLabel", "Text1");
            b.AddLabel("label2", "text2", new Anchor(0, 1));
            b.AddLabel("long", "Ještě mnohem délší text pro test",new Anchor(0,2));
            b.AddFrame("f", b.LenghthOfLongestLabel(), b.CountOfParts<TUILabelPart>(),new Anchor(-1,-1));
            b.AddFrame("f2", b.LenghthOfLongestLabel()+5, b.CountOfParts<TUILabelPart>()+5, new Anchor(-5, -5));
            b.AddLabel("popis1","Rámeček 1",new Anchor(-3, -5),ConsoleColor.DarkYellow);
            b.AddLabel("popis2", "R.2", new Anchor(1, -1),ConsoleColor.DarkYellow);
            objs.Add(b.Build(new Anchor(5,5)));

            ui.Menus.Add("TEST", objs);
            ui.OpenMenu("TEST");
*/
            Console.ReadKey();
            
        }
        public static void test() { 
            Random random = new Random();
            Console.Beep(random.Next(500,2500), 500); } 
        public static void Beeper()
        {
            Console.Beep(1200,250);
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
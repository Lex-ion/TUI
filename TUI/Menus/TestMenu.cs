using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Defaults;
using TUI.TUIParts.Builder;

namespace TUI.Menus
{
	public class TestMenu : AbstractTUIMenu
	{
		public TestMenu(TUIBuilderDefaults defaults, Color backGroundColor) : base(defaults, backGroundColor)
		{
		}

		protected override void BuilderInstructions(TUIObjectBuilder builder)
		{
			builder.AddButton("b", "Button 1");
			builder.Build("Batn1", new(5, 5));

			builder.AddButton("b", "Button 2");
			builder.Build("Batn2", new(15, 5));

			builder.AddButton("b", "Button 3");
			builder.Build("Batn3", new(26, 7));

			builder.AddButton("b", "Button 4");
			builder.Build("Batn4", new(20, 15));

			builder.AddButton("b", "Button 5");
			builder.Build("Batn5", new(40, 20));

			builder.AddPathSelector("p", 15, 5)
				.Build("p",new(80,8));


			Objects["Batn1"].TUIInteractable!.Interacted += Barvička;

		}

		public void Barvička()
		{
			Random rnd = new();
			BackGroundColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
			TUIManager.RedrawCurrent();
		}
	}
}

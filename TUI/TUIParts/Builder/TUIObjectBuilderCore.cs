using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Defaults;
using TUI.Structs;

namespace TUI.TUIParts.Builder
{
	public partial class TUIObjectBuilder //Core file containing essentials for builder
	{
		public TUIObject Product { get;protected set; }
		public TUIBuilderDefaults Defaults { get; set; }
		public Dictionary<string, TUIObject>? Output { get; set; }

		public TUIObjectBuilder()
		{
			Product=new TUIObject();
			Defaults=TUIBuilderDefaults.MasterDefault;
		}

		public TUIObjectBuilder(TUIBuilderDefaults defaults, Dictionary<string, TUIObject>? output)
		{

			Product = new TUIObject();
			Defaults = defaults;
			Output = output;
		}

		public TUIObjectBuilder(Dictionary<string, TUIObject>? output)
		{

			Product = new TUIObject();
			Defaults = TUIBuilderDefaults.MasterDefault;
			Output = output;
		}
		public void Reset() => Product = new();

		public TUIObject Build(Anchor anchor)
		{
			TUIObject finished = Product;
			finished.Anchor = anchor;
			Reset();
			return finished;
		}
		public TUIObject Build()
		{
			return Build(new Anchor());
		}

		public TUIObjectBuilder Build(string name, Anchor anchor)
		{
			if (Output == null)
				throw new Exception("Output dictionary is not set!");

			Output.Add(name, Build(anchor));
			return this;
		}
		public TUIObjectBuilder Build(string name)
		{
			if (Output == null)
				throw new Exception("Output dictionary is not set!");

			Output.Add(name, Build());
			return this;
		}

		void ValidateName(string name)
		{
			if (!string.IsNullOrEmpty(name))
				throw new ArgumentException("Invalid name!");
			else if (Product.Parts?.Keys.Any(k => k == name) ?? false)
				throw new ArgumentException("There is already part with that name!");
		}


	}
}

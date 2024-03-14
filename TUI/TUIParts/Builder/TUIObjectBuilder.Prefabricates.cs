using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TUI.Menus;
using TUI.Structs;

namespace TUI.TUIParts.Builder
{
    public partial class TUIObjectBuilder
	{
		private TUIObject? oldProduct;

		private void SaveProduct()
		{
			oldProduct = Product;
		}
		private void LoadProduct()
		{
			Product=oldProduct??throw new Exception("There is not saved product");
		}

		public TUIObject FabricateOverLay(int width, int height, Color color,Anchor anchor)
		{
			SaveProduct();
			Product = new();
			AddColorOverlay("FABRICATED_OVERLAY", width, height, color, new());
			Product.Anchor = anchor;

			TUIObject FabricatedObj = Product;
			LoadProduct();

			return FabricatedObj;
		}
	}
}

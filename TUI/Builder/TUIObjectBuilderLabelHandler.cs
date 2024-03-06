using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.TUIParts.Builder
{
	public partial class TUIObjectBuilder //Label addon
	{
		public TUIObjectBuilder AddLabel()
		{
			Build();
			return this;
		}
	}
}

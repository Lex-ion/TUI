using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI
{
    public class TUILabelFactory : AbstractTUIObjectPartFactory
    {
        

        public override ITUIObjectPart Create()
        {
            return new TUILabelPart();
        }
    }
}

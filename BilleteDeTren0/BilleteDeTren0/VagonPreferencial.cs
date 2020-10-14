using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class VagonPreferencial : Vagon
    {
        public override float getPrecio()
        {
            return 100;
        }

    }
}

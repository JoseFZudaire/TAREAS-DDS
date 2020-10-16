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

        public VagonPreferencial(bool esVagonFumador)
        {
            vagonFumador = esVagonFumador;
            for (int i = 0; i < 60; i++)
            {
                if (i % 2 == 0) { plazas[i] = new Plaza(true, i, false); }
                else { plazas[i] = new Plaza(false, i, false); }
            }
        }

    }
}

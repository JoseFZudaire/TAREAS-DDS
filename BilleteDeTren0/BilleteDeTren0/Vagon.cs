using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    abstract class Vagon
    {
        public Plaza[] plazas = new Plaza[60];

        public bool vagonFumador;

        public abstract float getPrecio();

    }
}

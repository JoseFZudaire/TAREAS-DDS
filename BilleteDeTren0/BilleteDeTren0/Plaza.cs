using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Plaza
    {
        public bool esPasillo;
        public int nroAsiento;
        public bool plazaVendida;

        public void reservar()
        {
            if (!plazaVendida)
            {
                plazaVendida = true;
            }
        }

    }
}

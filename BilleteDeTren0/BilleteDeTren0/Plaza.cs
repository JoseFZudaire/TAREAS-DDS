using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Plaza
    {
        private bool esPasillo;
        private int nroAsiento;
        private bool plazaVendida;

        public void reservar()
        {
            if (!plazaVendida) { plazaVendida = true; }
        }

        public bool getPlazaVendida () { return plazaVendida; }

        public Plaza (bool pasillo, int unNroAsiento, bool unaPlazaVendida)
        {
            esPasillo = pasillo;
            nroAsiento = unNroAsiento;
            plazaVendida = unaPlazaVendida;
        }

    }
}

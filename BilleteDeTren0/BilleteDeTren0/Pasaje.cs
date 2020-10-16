using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Pasaje
    {
        private Pasajero pasajero;
        private Plaza plaza;
        private float valor;
        private Viaje viaje;

        public Pasaje (Pasajero unPasajero, Plaza unaPlaza, float unValor, Viaje unViaje)
        {
            pasajero = unPasajero;
            plaza = unaPlaza;
            valor = unValor;
            viaje = unViaje;
        }

    }
}

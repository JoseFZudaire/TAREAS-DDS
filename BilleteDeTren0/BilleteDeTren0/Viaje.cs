using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Viaje
    {
        private string destino;
        private DateTime llegada;
        private string origen;
        private DateTime salida;
        private Tren tren;

        public Tren getTren() { return tren; }

        public Viaje (string unDestino, DateTime unaLlegada, string unOrigen, DateTime unaSalida, Tren unTren)
        {
            destino = unDestino;
            llegada = unaLlegada;
            origen = unOrigen;
            salida = unaSalida;
            tren = unTren;
        }

        public string getDestino() { return destino; }
    }
}

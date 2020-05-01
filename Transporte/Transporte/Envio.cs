using System;
using System.Collections.Generic;
using System.Text;

namespace Transporte
{
    class Envio
    {
        public string destino { get; set; }

        public Paquete paquete { get; set; }

        public Transportista transportista { get; set; }

        public Envio(string destino, Paquete paquete, Transportista transportista)
        {
            this.destino = destino;
            this.paquete = paquete;
            this.transportista = transportista;
        }
    }
}

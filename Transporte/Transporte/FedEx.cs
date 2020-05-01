using System;
using System.Collections.Generic;
using System.Text;

namespace Transporte
{
    class FedEx : Transportista
    {
        protected float costoPorVolumen = 4.5f;

        public override float calcularCosto(Paquete miPaquete, string miDestino)
        {
            return costoPorVolumen * miPaquete.volumen;

        }
    }
}

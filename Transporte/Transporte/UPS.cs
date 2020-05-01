using System;
using System.Collections.Generic;
using System.Text;

namespace Transporte
{
    class UPS : Transportista
    {
        protected float costoPorKilo = 9.41f;

        public override float calcularCosto(Paquete miPaquete, string miDestino)
        {
            return costoPorKilo * miPaquete.peso;
        }
    }
}

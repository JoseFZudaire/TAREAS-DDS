using System;
using System.Collections.Generic;
using System.Text;

namespace Transporte
{
    class Estandar : Transportista
    {
        List<string> zonasCercanas = new List<string> { "Vicente Lopez", "Florida", "Olivos" };

        protected float tarifaLocal = 5.41F;

        protected float tarifaLargaDistancia = 2.41F;

        public override float calcularCosto(Paquete miPaquete, string miDestino)
        {
            bool evaluacionDestino = esCercano(miDestino);

            if (evaluacionDestino)
            {
                return tarifaLocal * miPaquete.peso;
            }
            else
            {
                return tarifaLargaDistancia * miPaquete.peso;
            }
        }

        private bool esCercano(string unDestino)
        {
            return zonasCercanas.Contains(unDestino);

        }
    }
}

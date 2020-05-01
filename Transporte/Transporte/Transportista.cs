using System;
using System.Collections.Generic;
using System.Text;

namespace Transporte
{
    abstract class Transportista
    {
        public abstract float calcularCosto(Paquete miPaquete, string miDestino);
    }
}

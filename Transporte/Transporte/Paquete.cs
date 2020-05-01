using System;
using System.Collections.Generic;
using System.Text;

namespace Transporte
{
    class Paquete
    {
        public float peso { get; set; }
        public float volumen { get; set; }
        public Paquete(float peso, float volumen)
        {
            this.peso = peso;
            this.volumen = volumen;
        }
    }
}

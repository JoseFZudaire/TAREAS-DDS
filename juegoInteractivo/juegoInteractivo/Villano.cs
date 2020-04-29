using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Villano : Personaje
    {
        public Villano (float unaAltura, int unaInteligencia, string unNombre, float unPeso)
        {
            altura = unaAltura;
            // habilidades.AddRange(unasHabilidades);
            inteligencia = unaInteligencia;
            nombre = unNombre;
            peso = unPeso;
        }

    }
}

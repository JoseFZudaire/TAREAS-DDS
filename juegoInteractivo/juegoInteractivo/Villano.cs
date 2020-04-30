using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Villano : Personaje
    {
        public Villano():base() { }

        public Villano(string nombre, float peso, float altura, int inteligencia, string[] habilidades) : base(nombre, peso, altura, inteligencia, habilidades) { }

        public override Personaje copiar()
        {
            return (Villano)this.MemberwiseClone();
        }
    }
}

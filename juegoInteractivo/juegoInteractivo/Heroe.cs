using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Heroe : Personaje
    {
        public Heroe() { }

        public Heroe(string nombre, float peso, float altura, int inteligencia, string[] habilidades) : base(nombre, peso, altura, inteligencia, habilidades) { }

        public override Personaje copiar()
        {
            return (Heroe)this.MemberwiseClone();
        }
    }
}

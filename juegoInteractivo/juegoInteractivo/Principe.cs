using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Principe : Personaje
    {
        public Principe() { }

        public Principe(string nombre, float peso, float altura, int inteligencia, string[] habilidades) : base(nombre, peso, altura, inteligencia, habilidades) { }

        public override Personaje copiar()
        {
            return (Principe)this.MemberwiseClone();
        }
    }
}

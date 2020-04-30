using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Monstruo : Personaje
    {
        public Monstruo() { }

        public Monstruo(string nombre, float peso, float altura, int inteligencia, string[] habilidades) : base(nombre, peso, altura, inteligencia, habilidades) { }

        public override Personaje copiar()
        {
            return (Monstruo)this.MemberwiseClone();
        }
    }
}

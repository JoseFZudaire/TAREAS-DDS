using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Sesion
    {
        protected List<Personaje> personajes { get; set; }


        public Sesion(List<Personaje> personajes)
        {
            this.personajes = personajes;
        }
        
        public void addPersonaje(Personaje p) { personajes.Add(p); }

        public void removePersonaje(Personaje p) { personajes.Remove(p); }
    }
}

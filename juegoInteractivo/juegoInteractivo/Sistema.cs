using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Sistema
    {
        protected List<Personaje> personajesCreados{ get; set; }
        protected List<Sesion> sesiones { get; set; }
        protected static Sistema _instance;

        protected Sistema() { }

        public static Sistema getInstance()
        {
            if (_instance == null)
            {
                _instance = new Sistema();
                _instance.personajesCreados = new List<Personaje>();
                _instance.sesiones = new List<Sesion>();
            }
            return _instance;
        }

        public void addPersonaje(Personaje pers) { personajesCreados.Add(pers); }
        public void removePersonaje(Personaje pers) { personajesCreados.Remove(pers); }

        public void addSesion(Sesion sesion) { sesiones.Add(sesion); }
        public void removeSesion(Sesion sesion) { sesiones.Remove(sesion); }


        public Sesion crearSesion(List<Personaje> personajesElegidos)
        {
            List<Personaje> personajesCopiados = copiarPersonajes(personajesElegidos);
            Sesion unaSesion = new Sesion(personajesCopiados);
            this.addSesion(unaSesion);

            return unaSesion;
        }

        public List<Personaje> copiarPersonajes(List<Personaje> personajes)
        {
            List<Personaje> copiasPersonajes = new List<Personaje>();
            personajes.ForEach(p => copiasPersonajes.Add(p.copiar()));

            return copiasPersonajes;
        }



        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace juegoInteractivo
{
    class Sistema
    {
        private List<Personaje> personajesCreados;
        private List<Sesion> sesiones;
        private static Sistema _instance;

        protected Sistema() { }

        public Sesion crearSesion(String personajesElegidos)
        {
            List<Personaje> personajesCopiados = copiarPersonajes(personajesElegidos);

            Sesion unaSesion = new Sesion(personajesCopiados);

            sesiones.Add(unaSesion);

            return unaSesion;
        }

        public List<Personaje> copiarPersonajes(String personajesElegidos)
        {
            List<Personaje> copiasPersonajes = new List<Personaje>();
            List<Personaje> losPersonajes = new List<Personaje>();
            //void copiarlos(Personaje p) { copiasPersonajes.Add(p.copiar()); }
            string[] personajes = personajesElegidos.Split(",");
            foreach (string element in personajes)
            {
                //busco dentro de los personajes creados los que tienen alguno de los nombres que pasé por parametro y los agrego a una lista de copias
                losPersonajes.Add(personajesCreados.Find(p => p.getNombre() == element));
            }
            losPersonajes.ForEach(delegate (Personaje p) { copiasPersonajes.Add(p.copiar()); });

            return copiasPersonajes;
        }

        //public List<Personaje> elegirPersonaje()

        public static Sistema getInstance()
        {
            if (_instance == null)
            {
                _instance = new Sistema();
            }
            return _instance;
        }
    }
}

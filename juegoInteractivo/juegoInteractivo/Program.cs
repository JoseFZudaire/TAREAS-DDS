using System;
using System.Collections.Generic;

namespace juegoInteractivo
{
    class Program
    {
        Sistema sistema = Sistema.getInstance();

        static void Main(string[] args)
        {
            Sistema sistema = Sistema.getInstance();
            Sesion sesionActual;

            Monstruo maloso = new Monstruo("el oso maloso", 325, 275, 50, new string[]{"comer miel", "hibernar"});
            Villano popote = new Villano("popote", 50, 100, 570, new string[] { "viajar en el tiempo", "superinteligencia"});
            Heroe superman = new Heroe("superman", 110, 190, 270, new string[] { "volar", "super fuerza" });
            
            sesionActual = sistema.crearSesion(sistema.elegirPersonajes("popote, el oso maloso"));

        }




            /*
            static void Main(string[] args)
            {
                Console.WriteLine("0: Salir, 1: Crear Personaje, 2: Crear Sesion");
                int menu = Convert.ToInt32(Console.ReadLine());

                while (menu != 0)
                {
                    switch (menu)
                    {
                        case 1:
                            menuCrearPersonaje();
                            break;
                        case 2:
                            menuCrearSesion();
                            break;

                    }

                    Console.WriteLine("0: Salir, 1: Crear Personaje, 2: Crear Sesion");
                    menu = menu = Convert.ToInt32(Console.ReadLine());
                }

            }

            static void menuCrearSesion()
            {
                Console.WriteLine("Los personajes disponibles son:" +
                                  "(escriba los personajes elegidos separados" +
                                  "por coma, sin espacios, para agregarlos a la sesion)");
                sistema.getPersonajesCreados().ForEach(p=>Console.WriteLine(p.getNombre()));

                string persElegidos = Console.ReadLine();
                sistema.crearSesion(persElegidos);

            }

            static void menuCrearPersonaje()
            {
                Console.WriteLine("Que personaje quiere crear? Principe(p), Monstruo(m), Villano(v), Heroe(h)");
                int tipo = Console.ReadLine().ToCharArray()[0];
                Console.WriteLine("Ingrese el nombre del personaje: ");
                string nombre = Console.ReadLine();


                switch (tipo)
                {
                    case 'p':
                        Principe p = new Principe(nombre, 10, 160, 100, "nada");
                        sistema.addPersonaje(p);
                        break;
                    case 'm':
                        Monstruo m = new Monstruo(nombre, 10, 160, 100, "nada");
                        sistema.addPersonaje(m);
                        break;
                    case 'v':
                        Villano v = new Villano(nombre, 10, 160, 100, "nada");
                        sistema.addPersonaje(v);
                        break;
                    case 'h':
                        Heroe h = new Heroe(nombre, 10, 160, 100, "nada");
                        sistema.addPersonaje(h);
                        break;
                }
            }
            */
        }
}

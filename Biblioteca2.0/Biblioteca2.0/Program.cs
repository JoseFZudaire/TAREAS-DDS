using Microsoft.EntityFrameworkCore.Diagnostics;
using Renci.SshNet;
using System;
using System.Linq;

namespace Biblioteca2._0
{
    class Program
    {
        public static DB context { get; set; }
        static void Main(string[] args)
        {
            context = new DB();
            //crearEjemplo();
            int ingreso;

            Console.WriteLine("Ingrese una opcion\n0: salir,\n1: agregar un prestamo,\n2: devolver un libro,\n3: calcular multa");
            ingreso = Convert.ToInt32(Console.ReadLine());

            while (ingreso != 0)
            {
                switch (ingreso)
                {
                    case 1:
                        agregarPrestamo();
                        Console.WriteLine("Prestamo agregado");
                        break;
                    case 2:
                        devolverLibro();
                        break;
                    case 3:
                        //calcularMulta();
                        break;
                    default:
                        Console.WriteLine("Ingreso invalido");
                        break;
                }
                Console.WriteLine("Ingrese una opcion\n0: salir,\n1: agregar un prestamo,\n2: devolver un libro,\n3: calcular multa");
                ingreso = Convert.ToInt32(Console.ReadLine());
            }



        }

        private static void devolverLibro()
        {
            Lector lec = seleccionarLector();
            Prestamo pres = seleccionarPrestamo(lec);
        }

        private static void agregarPrestamo()
        {

            Prestamo pres = new Prestamo();
            pres.lector = seleccionarLector();
            pres.libro = seleccionarLibro();
            pres.libro.estado = Estado.Prestado;
            Console.WriteLine("Ingrese la cantidad de dias del prestamo: ");
            pres.cantDias = Convert.ToInt32(Console.ReadLine());
            pres.fechaInicio = DateTime.Now;
            pres.prestamoActivo = true;
            context.Prestamos.Add(pres);
            context.SaveChanges();

        }

        private static Prestamo seleccionarPrestamo(Lector lec)
        {
            Prestamo[] prestamosActivos = context.getPrestamosActivosDe(lec);
            for (int i = 0; i < prestamosActivos.Length; i++)
            {
                Console.WriteLine(i + ": " + prestamosActivos[i].libro.nombre);
            }
            Console.Write("Ingrese el prestamo a devolver: ");
            int seleccion = Convert.ToInt32(Console.ReadLine());
            while (seleccion < 0 && seleccion > prestamosActivos.Length - 1)
            {
                Console.Write("Ingreso invalido. Ingrese el prestamo a devolver: ");
                seleccion = Convert.ToInt32(Console.ReadLine());
            }
            return prestamosActivos[seleccion];
        }

        private static Lector seleccionarLector()
        {
            Lector[] lectores = context.getLectoresDisponibles();
            for (int i = 0; i < lectores.Length; i++)
            {
                Console.WriteLine(i + ": " + lectores[i].nombre);
            }
            Console.Write("Ingrese el lector: ");
            int seleccion = Convert.ToInt32(Console.ReadLine());
            while (seleccion < 0 && seleccion > lectores.Length - 1)
            {
                Console.Write("Ingreso invalido. Ingrese el lector: ");
                seleccion = Convert.ToInt32(Console.ReadLine());
            }
            return lectores[seleccion];
        }
        private static Libro seleccionarLibro()
        {
            Libro[] libros = context.getLibrosDisponibles();
            for (int i = 0; i < libros.Length; i++)
            {
                Console.WriteLine(i + ": " + libros[i].nombre);
            }

            Console.Write("Ingrese el libro que desea prestar: ");
            int seleccion = Convert.ToInt32(Console.ReadLine());
            while (seleccion < 0 && seleccion > libros.Length - 1)
            {
                Console.Write("Ingreso invalido. Ingrese el libro que desea prestar: ");
                seleccion = Convert.ToInt32(Console.ReadLine());
            }

            return libros[seleccion];
        }

        private static void crearEjemplo()
        {
            Autor autor1 = new Autor(new DateTime(1968, 2, 12), "Argentina", "Juan Perez");
            Autor autor2 = new Autor(new DateTime(1894, 6, 26), "Reino Unido", "Aldous Huxley");
            context.Add<Autor>(autor1);
            context.SaveChanges();
            Libro libro1 = new Libro("El misterio de los patos", autor1,2016, "Drama", "Salamandra");
            Libro libro2 = new Libro("Un mundo feliz", autor2, 1932, "Ficcion distopica", "Debolsillo");
            context.Add<Libro>(libro1);
            context.Add<Libro>(libro2);
            Lector lector1 = new Lector("Lucas Miller");
            Lector lector2 = new Lector("Matias Soto");
            context.Add<Lector>(lector1);
            context.Add<Lector>(lector2);
            context.SaveChanges();


        }
    }
}

using Microsoft.EntityFrameworkCore.Diagnostics;
using Renci.SshNet;
using System;
using System.Linq;
using System.Threading;

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

            Console.WriteLine("Ingrese una opcion\n0: salir,\n1: agregar un prestamo,\n2: devolver un libro,\n3: calcular multa de prestamo");
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
                        Console.WriteLine("Libro devuelto");
                        break;
                    case 3:
                        calcularMulta();
                        break;
                    default:
                        Console.WriteLine("Ingreso invalido");
                        break;
                }
                Console.WriteLine("Ingrese una opcion\n0: salir,\n1: agregar un prestamo,\n2: devolver un libro,\n3: calcular multa");
                ingreso = Convert.ToInt32(Console.ReadLine());
            }
            


        }


        private static void calcularMulta() //Se fija si para un prestamo activo le cabe una multa al lector
        {
            Prestamo pres = seleccionarPrestamo(context.Prestamos.Where(p=>p.prestamoActivo).ToArray());
            int multa = pres.calcularDiasMulta();
            if (multa < 1)
                Console.WriteLine("La devolucion se realizo a tiempo");
            else
                Console.WriteLine("La devolucion fue con retraso. Los dias de multa aplicados son: "+multa);
        }

        private static void devolverLibro()
        {
            Lector lec = seleccionarLector(context.Lectores.ToArray());
            Prestamo pres = seleccionarPrestamo(context.getPrestamosActivosDe(lec));
            pres.prestamoActivo = false;
            if((DateTime.Now - pres.fechaInicio).TotalDays > pres.cantDias)
            {
                lec.aplicarMulta(pres);
            }
            pres.libro.estado = Estado.EnBiblioteca;
            context.SaveChanges();
        }

        private static Prestamo seleccionarPrestamo(Prestamo[] prestamosActivos)
        {
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


        private static void agregarPrestamo()
        {

            Prestamo pres = new Prestamo();
            pres.lector = seleccionarLector(context.getLectoresDisponibles());
            pres.libro = seleccionarLibro();
            pres.libro.estado = Estado.Prestado;
            Console.WriteLine("Ingrese la cantidad de dias del prestamo: ");
            pres.cantDias = Convert.ToInt32(Console.ReadLine());
            pres.fechaInicio = DateTime.Now;
            pres.prestamoActivo = true;
            context.Prestamos.Add(pres);
            context.SaveChanges();

        }

        private static Lector seleccionarLector(Lector [] lectores)
        {
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

            Autor autor1 = new Autor(new DateTime(1908, 4, 5), "Estadounidense", "Edgar Alan Poe");
            context.Add<Autor>(autor1);
            Libro libro1 = new Libro("El sabueso de los Baskerville", autor1, 1941, "Policial", "Santillana");
            context.Add<Libro>(libro1);
            Lector lector1 = new Lector("Pipo Fuentes");
            context.Add<Lector>(lector1);
            context.SaveChanges();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public enum Estado
{
    EnBiblioteca = 0,
    Prestado = 1,
    EnRetraso = 2,
    EnReparacion = 3
}

namespace Biblioteca
{
    public class Libro
    {

        public int idLibro { get; set; }
        public int anio { get; set; }
        public String categoria { get; set; }
        public String editorial { get; set; }
        public int idAutor { get; set; }
        public Estado estado { get; set; }
        public String nombre { get; set; }
        public List<Prestamo> prestamos { get; set; }
        public Autor autor { get; set; }


        public Libro( int unAnio, String unaCategoria, String unaEditorial, int autorId, Estado unEstado, String unNombre, Autor unAutor) {
            anio = unAnio;
            categoria = unaCategoria;
            editorial = unaEditorial;
            idAutor = autorId;
            estado = unEstado;
            nombre = unNombre;
            autor = unAutor;
        }

        public Boolean cumpleCondicionesPrestamo()
        {
            switch (estado)
            {
                case Estado.EnBiblioteca:
                    return true;
                case Estado.EnReparacion:
                    Console.WriteLine("Se encuentra en reparación.");
                    return false;
                case Estado.EnRetraso:
                    Console.WriteLine("Se encuentra en retraso.");
                    return false;
                case Estado.Prestado:
                    Console.WriteLine("Se encuentra prestado.");
                    return false;
            }
            return false;
        }

    }
}

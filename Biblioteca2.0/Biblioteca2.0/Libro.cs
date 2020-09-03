using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
//using System.Runtime.Remoting.W3cXsd2001;
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

namespace Biblioteca2._0
{
    public class Libro
    {

        public int idLibro { get; set; }
        public int anio { get; set; }
        public string categoria { get; set; }
        public string editorial { get; set; }
        public int idAutor { get; set; }
        public Estado estado { get; set; }
        public string nombre { get; set; }
        public List<Prestamo> prestamos { get; set; }
        public Autor autor { get; set; }

        public Libro()
        {

        }

        public Libro(string unNombre, Autor unAutor, int unAnio, string unaCategoria, string unaEditorial) {
            anio = unAnio;
            categoria = unaCategoria;
            editorial = unaEditorial;
            nombre = unNombre;
            autor = unAutor;
        }

        public Boolean cumpleCondicionesPrestamo()
        {
            if (estado == Estado.EnBiblioteca)
                return true;
            return false;
        }

    }
}

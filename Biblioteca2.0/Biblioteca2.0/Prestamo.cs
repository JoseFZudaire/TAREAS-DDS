using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2._0
{
    public class Prestamo
    {
        public int cantDias { get; set; }
        public DateTime fechaInicio { get; set; }
        public int idPrestamo { get; set; }
        public int idLibro { get; set; }
        public int idLector { get; set; }
        public Lector lector { get; set; }
        public Libro libro { get; set; }

        public Prestamo()
        {

        }
        public Prestamo(int dias, DateTime inicio, int libroId, int lectorId, Lector unLector, Libro unLibro)
        {
            cantDias = dias;
            fechaInicio = inicio;
            idLibro = libroId;
            idLector = lectorId;
            lector = unLector;
            libro = unLibro;
        }

    }
}

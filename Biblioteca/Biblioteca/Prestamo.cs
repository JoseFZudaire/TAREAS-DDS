using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Prestamo
    {
        private int cantDias;
        private DateTime fechaInicio;
        private int idPrestamo;
        private int idLibro;
        private int idLector;
        private Lector lector;
        private Libro libro;

        public Libro getLibro() { return libro; }

        public void setPrestamo(int dias, DateTime inicio, int prestamoId, int libroId, int lectorId, Lector unLector, Libro unLibro)
        {
            cantDias = dias;
            fechaInicio = inicio;
            prestamoId = idPrestamo;
            idLibro = libroId;
            idLector = lectorId;
            lector = unLector;
            libro = unLibro;
        }

        public int getCantDias() { return cantDias; }

    }
}

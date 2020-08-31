using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Lector
    {



        public int idLector { get; set; }
        public String nombre { get; set; }

        public int diasDeMulta { get; set; }
        public List <Prestamo> prestamos { get; set; }
 
        public Lector(String nombre, int diasMulta)
        {
            
            this.nombre = nombre;
            diasDeMulta = diasMulta;
        }

        public void aplicarMulta(Prestamo prestamo)
        {
            diasDeMulta = diasDeMulta + 2*(prestamo.getCantDias() - 30);
        }

        public void devolverLibro(Prestamo prestamo)
        {
            prestamos.Remove(prestamo);
            prestamo.libro.estado(Estado.EnBiblioteca);
        }

        public void realizarPrestamo(Prestamo prestamo)
        {
            if(prestamos.Count() < 3 && diasDeMulta == 0) 
            {
                if (prestamo.getLibro)
                prestamos.Add(prestamo);
                prestamo.getLibro().setEstado(Estado.Prestado);
            }
            else { Console.WriteLine("No se pueden prestar libros a este lector.");  }
        }

    }

}
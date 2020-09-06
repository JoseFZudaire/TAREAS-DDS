using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2._0
{
    public class Lector
    {
        public int idLector { get; set; }
        public String nombre { get; set; }
        public DateTime multadoHasta { get; set; }
        public List<Prestamo> prestamos { get; set; }

        public Lector()
        {

        }
        public Lector(String nombre)
        {
            this.nombre = nombre;
        }

        public void aplicarMulta(Prestamo prestamo)
        {
            this.multadoHasta = DateTime.Now.AddDays(prestamo.calcularDiasMulta());
        }

        

    }

}
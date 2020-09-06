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
        public bool prestamoActivo { get; set; }
        public Lector lector { get; set; }
        public Libro libro { get; set; }

        

        public Prestamo()
        {
        }
        

        public int calcularDiasMulta()
        {
            return (int)(DateTime.Now - fechaInicio.AddDays(cantDias)).TotalDays*2;//me fijo cuantos dias pasaron desde el dia que lo 
                                                                              //deberia haber devuelto y lo multiplico por 2
        }
        
        public void chequearDevolucion(Prestamo pres)
        {

            if((DateTime.Now - fechaInicio).TotalDays > cantDias)
            {
                 calcularDiasMulta();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Autor
    {
        
        public DateTime fechaNac { get; set; }
        public String nacionalidad { get; set; }
        public String nombre { get; set; }
        public int idAutor { get; set; }
        public List <Libro> libros { get; set; }

        public Autor(DateTime nacimiento, String unaNacionalidad, String unNombre)
        {
            fechaNac = nacimiento;
            nacionalidad = unaNacionalidad;
            nombre = unNombre;
        }


    }
}

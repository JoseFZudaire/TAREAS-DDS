using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Autor
    {
        
        public int fechaNac { get; set; }
        public String nacionalidad { get; set; }
        public String nombre { get; set; }
        public int idAutor { get; set; }
        public List <Libro> libros { get; set; }

        public Autor(int nacimiento, String unaNacionalidad, String unNombre)
        {
            fechaNac = nacimiento;
            nacionalidad = unaNacionalidad;
            nombre = unNombre;
        }


    }
}

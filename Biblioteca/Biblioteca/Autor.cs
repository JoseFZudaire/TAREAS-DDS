using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Autor
    {
        public DateTime fechaNac { get; set; }
        public String nacionalidad { get; set; }
        public String nombre { get; set; }
        public int idAutor { get; set; }
        public List <Libro> libros { get; set; }

        public void setAutor(DateTime nacimiento, String unaNacionalidad, String unNombre, int id)
        {
            fechaNac = nacimiento;
            nacionalidad = unaNacionalidad;
            nombre = unNombre;
            idAutor = id;
        }


    }
}

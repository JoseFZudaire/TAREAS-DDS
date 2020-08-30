using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Autor
    {
        private DateTime fechaNac;
        private String nacionalidad;
        private String nombre;
        private int idAutor;
        private List <Libro> libros;

        public void setAutor(DateTime nacimiento, String unaNacionalidad, String unNombre, int id)
        {
            fechaNac = nacimiento;
            nacionalidad = unaNacionalidad;
            nombre = unNombre;
            idAutor = id;
        }


    }
}

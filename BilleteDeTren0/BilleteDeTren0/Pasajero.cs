using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Pasajero
    {
        private string apellido;
        private string DNI;
        private bool esFumador;
        private string nombre;

        public bool getFumador() { return esFumador; }

        public Pasajero (string unApellido, string unDNI, bool fumador, string unNombre)
        {
            apellido = unApellido;
            DNI = unDNI;
            esFumador = fumador;
            nombre = unNombre;
        }
    }
}

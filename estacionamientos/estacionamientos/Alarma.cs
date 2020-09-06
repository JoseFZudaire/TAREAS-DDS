using System;
using System.Collections.Generic;
using System.Text;

namespace estacionamientos
{
    class Alarma
    {
        bool activada = false;
        public void activar()
        {
            activada = true;           
        }

        public void desactivar()
        {
            activada = false;
        }

    }
}

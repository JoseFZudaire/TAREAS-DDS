using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Tren
    {
        Vagon[] vagones = new Vagon[8];

        public bool chequearDisponibilidad(int cant, bool fumador, bool preferencial)
        {

            int i = 0;
            int cantAsientos = 0;
            
            for (int contVagon = 1; contVagon <= 8; contVagon++)
            { 
                if (contVagon < 5 && preferencial) { i++; }
                else if (contVagon > 4 && !preferencial) { i++; }

                if (contVagon > 2 && contVagon < 7 && fumador) { i++; }
                else if (contVagon < 3 && contVagon > 6 && !fumador) { i++; }

                foreach(Plaza plaza in vagones[contVagon].plazas)
                {
                    if (!plaza.plazaVendida) { i++; }
                }
                
                if (i == 3) { cantAsientos++; }
                i = 0;
            }
            
            if (cant >= cantAsientos) { return true; }
            else { return false; }
            
        }

    }
}

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

        public Tren ()
        {
            vagones[0] = new VagonPreferencial(false);
            vagones[1] = new VagonPreferencial(false);
            vagones[2] = new VagonPreferencial(true);
            vagones[3] = new VagonPreferencial(true);
            vagones[4] = new VagonTurista(true);
            vagones[5] = new VagonTurista(true);
            vagones[6] = new VagonTurista(false);
            vagones[7] = new VagonTurista(false);
        }

        public Vagon[] getVagones() { return vagones; }

        public bool chequearDisponibilidad(int cant, bool fumador, bool preferencial)
        {
            int i = 0;
            int cantAsientos = 0;
            
            for (int contVagon = 0; contVagon < 8; contVagon++)
            { 
                if (contVagon < 4 && preferencial) { i++; }
                else if (contVagon > 3 && !preferencial) { i++; }

                if (contVagon > 1 && contVagon < 6 && fumador) { i++; }
                else if ((contVagon < 2 || contVagon > 5) && !fumador) { i++; }

                foreach(Plaza plaza in vagones[contVagon].plazas)
                {
                    if (!plaza.getPlazaVendida() && i==2) { i++; }
                    if (i == 3) { cantAsientos++; i--; }
                }
                
                i = 0;
            }
            if (cant <= cantAsientos) { return true; }
            else { return false; }
            
        }

    }
}

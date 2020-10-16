using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Controller
    {
        private List<Viaje> viajes = new List<Viaje>();
        private List<Pasaje> pasajes = new List<Pasaje>();
        private List<Pasaje> pasajesComprados = new List<Pasaje>();

        public List<Pasaje> comprarPasajes(bool esPreferencial, Viaje viaje, Pasajero [] pasajeros) {

            pasajesComprados.Clear();
            int contador = 0;
            foreach (Pasajero pasajero in pasajeros) {
                if (viaje.getTren().chequearDisponibilidad(1, pasajero.getFumador(), esPreferencial)) { contador++; }
            }
            Console.WriteLine(contador);
            if (contador == pasajeros.Length)
            {
                viajes.Add(viaje);
                foreach (Pasajero pasajero in pasajeros)
                {
                    int i = 0;
                    for (int contVagon = 0; contVagon < 8; contVagon++)
                    {
                        if (contVagon < 4 && esPreferencial) { i++; }
                        else if (contVagon > 3 && !esPreferencial) { i++; }

                        if (viaje.getTren().getVagones()[contVagon].vagonFumador && pasajero.getFumador()) { i++; }
                        else if (!viaje.getTren().getVagones()[contVagon].vagonFumador && !pasajero.getFumador()) { i++; }

                        foreach (Plaza plaza in viaje.getTren().getVagones()[contVagon].plazas)
                        {
                            if (!plaza.getPlazaVendida() && i == 2) { i++; }
                            if (i == 3) { 
                                plaza.reservar(); 
                                i = 0;
                                Pasaje nuevoPasaje = new Pasaje(pasajero, plaza, viaje.getTren().getVagones()[contVagon].getPrecio(), viaje);
                                pasajesComprados.Add(nuevoPasaje);
                                pasajes.Add(nuevoPasaje);
                            }
                        }
                        i = 0;
                    }
                }
            }
            return pasajesComprados;        
        }
        public void pagarConTarjeta() {}
        public void pagarEfectivo() {}
        public List<Viaje> getViajes() { return viajes; }
    }
}

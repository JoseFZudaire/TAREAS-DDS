using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteDeTren0
{
    class Program
    {
        static void Main(string[] args)
        {

            Controller unControlador = new Controller();

            Pasajero jose = new Pasajero("Zudaire", "41007286", false, "José");
            Pasajero bonjovi = new Pasajero("Bongiovi", "1234567", true, "John");

            DateTime hora1 = new DateTime(2020, 10, 16, 8, 0, 0);
            DateTime hora2 = new DateTime(2020, 10, 16, 8, 30, 0);

            Tren unTren = new Tren();

            Viaje unViaje = new Viaje("Pergamino", hora1, "Retiro", hora2, unTren);

            Pasajero[] pasajeros = { jose, bonjovi };

            unControlador.comprarPasajes(false, unViaje, pasajeros);

            Console.WriteLine("Todo OK");
            foreach (Viaje viaje in unControlador.getViajes()) {
                Console.WriteLine(viaje.getDestino());
            }
            Console.ReadLine();

        }
    }
}

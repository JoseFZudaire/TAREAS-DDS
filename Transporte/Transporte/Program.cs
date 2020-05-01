using System;

namespace Transporte
{
    class Program
    {
        static void Main(string[] args)
        {
            Paquete miPaquete = new Paquete(3, 8);

            Envio miEnvio = new Envio("Vicente Lopez", miPaquete, new UPS());

            float costo = miEnvio.transportista.calcularCosto(miPaquete, miEnvio.destino);

            imprimirCosto(costo);

        }
        static void imprimirCosto(float costo)
        {
            Console.WriteLine("El costo total es " + costo);
        }
    }
}

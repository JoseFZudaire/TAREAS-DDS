using System;
using System.Collections.Generic;

namespace estacionamientos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Escriba un caracter para iniciar el pago de un ticket. Si quiere salir del programa, presione E (Exit)");
            while (Console.ReadKey().Key != ConsoleKey.E)
            {
                double importe;
                Cajero cajero1 = new Cajero();
                double pago = 100;
                List<int> vuelto = new List<int>(10);
                List<double> valoresCambio = new List<double> { 100, 50, 20, 10, 5, 2, 1, 0.5, 0.25, 0.1 };

                DateTime hora1 = new DateTime(2020, 09, 04, 18, 0, 0);
                DateTime hora2 = new DateTime(2020, 09, 04, 21, 0, 0);
                Ticket ticket1 = new Ticket(hora1, hora2, false, "Jose");

                importe = cajero1.calcularImporte(ticket1);

                vuelto = cajero1.verificarIngreso(pago);

                if (vuelto.Count == 10)
                {

                    Console.WriteLine("Su vuelto es ");

                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(vuelto[i].ToString() + "de" + valoresCambio[i].ToString());
                    }
                    Console.WriteLine("Presione cualquier caracter para retirar su ticket.");
                    cajero1.retenerTicket(ticket1);

                }
                else
                {
                    Console.WriteLine("El dinero ingresado no fue adecuado para cubrir el importe del ticket.");
                }

                Console.WriteLine("Escriba un caracter para iniciar el pago de un ticket. Si quiere salir del programa, presione E (Exit)");

            }
            

        }
    }
}

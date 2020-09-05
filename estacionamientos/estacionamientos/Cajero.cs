using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace estacionamientos
{

    class Cajero
    {
        private double precio = 20;
        private List<Ticket> ticketsRetenidos = new List<Ticket>(100);
        private double totalImporte;
        public bool tieneCambio = true;

        private List<int> calcularCambio(double diferencia)
        {
            //en $ [100,50,20,10,5,2,1,0.5,0.25,0.1]

            if (tieneCambio)
            {
                List<int> cambio = new List<int>(10);
                for (int i = 0; i < 10; i++) cambio.Add(0);

                List<double> valoresCambio = new List<double> { 100, 50, 20, 10, 5, 2, 1, 0.5, 0.25, 0.1 };

                for (int i = 0; i < 10; i++)
                {
                    cambio[i] = (int)Math.Truncate(diferencia / valoresCambio[i]);
                    diferencia = diferencia - cambio[i] * valoresCambio[i];
                    if (diferencia>0 && i==9)
                    {
                        cambio[i] = cambio[i] + 1;
                    }
                }
                return cambio;
            }
            else {
                return new List<int> { 0, 0 };
            }
                       
        }
        public double calcularImporte(Ticket ticketCliente)
        {
            int horasEstacionadas = contabilizarTiempo(ticketCliente.getHoraSalida(), ticketCliente.getHoraEntrada());
            totalImporte = precio * horasEstacionadas;
            if (tieneCambio == false)
            {
                Console.WriteLine("El sistema tiene no cambio.");
            }
            return totalImporte;
        }
        private int contabilizarTiempo(DateTime horaSalida, DateTime horaEntrada)
        {
            TimeSpan duracion = horaSalida - horaEntrada;
            return (int) duracion.TotalHours;
        }
        public void retenerTicket(Ticket ticketCliente)
        {
            Alarma alarma = new Alarma();
            int tiempo = 15000;
            while (Console.KeyAvailable == false && tiempo > 0) { 
                System.Threading.Thread.Sleep(100);
                tiempo = tiempo - 100;
            }
            if (Console.KeyAvailable == false)
            {
                tiempo = 15000;

                alarma.activar();
                while (Console.KeyAvailable == false && tiempo > 0)
                {
                    System.Threading.Thread.Sleep(100);
                    tiempo = tiempo - 100;
                }
                alarma.desactivar();
                ticketsRetenidos.Add(ticketCliente);
                Console.WriteLine("Ticket retenido");
            }
        }
        public List<int> verificarIngreso(double dineroCobrado)
        {
            if (dineroCobrado > totalImporte)
            {
                return calcularCambio(dineroCobrado - totalImporte);
            }
            else
            {
                return new List<int> { 0 };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace estacionamientos
{
    class Ticket    
    {

        private DateTime horaEntrada;
        private DateTime horaSalida;
        private bool pagado;
        private string usuario;

        public Ticket(DateTime horaEntrada, DateTime horaSalida, bool pagado, string usuario)
        {
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
            this.pagado = pagado;
            this.usuario = usuario;
        }

        public void pagarTicket()
        {
            pagado = true;
        }

        public DateTime getHoraEntrada()
        {
            return horaEntrada;
        }

        public DateTime getHoraSalida()
        {
            return horaSalida;
        }

    }
}

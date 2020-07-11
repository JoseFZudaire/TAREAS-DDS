using System;
using System.Collections.Generic;
using System.Text;

namespace InteresesBancarios
{
    class Intereses : Visitor
    {

        public double visit(CajaDeAhorro cajaAhorro)
        {
            return 0.01 * cajaAhorro.getMonto() + cajaAhorro.getMonto();
        }
        public double visit(CuentaCorriente cuentaCorriente)
        {
            return 0.01 * cuentaCorriente.getMonto() + cuentaCorriente.getMonto();
        }
        public double visit(TarjetaDeCredito tarjeta)
        {
            return 0.05 * tarjeta.getMonto() + tarjeta.getMonto();
        }
    }
}

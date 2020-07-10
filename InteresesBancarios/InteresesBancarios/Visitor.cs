using System;
using System.Collections.Generic;
using System.Text;

namespace InteresesBancarios
{
    interface Visitor
    {
        public double visit(TarjetaDeCredito tarjetaDeCredito);
        public double visit(CuentaCorriente cuentaCorriente);
        public double visit(CajaDeAhorro cajaDeAhorro);

    }
}

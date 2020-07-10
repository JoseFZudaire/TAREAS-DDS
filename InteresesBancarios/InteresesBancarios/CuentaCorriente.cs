using System;
using System.Collections.Generic;
using System.Text;

namespace InteresesBancarios
{
    class CuentaCorriente
    {
        private double monto;
        public double accept(Visitor visitor) { return visitor.visit(this); }
        public void setMonto(double nuevoMonto) { this.monto = nuevoMonto; }
        public double getMonto() { return this.monto; }
    }
}

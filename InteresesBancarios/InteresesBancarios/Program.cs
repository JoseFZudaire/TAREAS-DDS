using System;

namespace InteresesBancarios
{
    class Program
    {
        static void Main(string[] args)
        {
            TarjetaDeCredito tarjeta = new TarjetaDeCredito();
            tarjeta.setMonto(12000);

            CajaDeAhorro caja = new CajaDeAhorro();
            caja.setMonto(80000);

            CuentaCorriente cuentacorriente = new CuentaCorriente();
            cuentacorriente.setMonto(30000);

            Intereses intereses = new Intereses();

            Console.WriteLine("Tarjeta sin intereses");
            Console.WriteLine(tarjeta.getMonto());
            Console.WriteLine("Caja de ahorro sin intereses");
            Console.WriteLine(caja.getMonto());
            Console.WriteLine("Cuenta corriente sin intereses");
            Console.WriteLine(cuentacorriente.getMonto());

            Console.WriteLine("Tarjeta con intereses");
            Console.WriteLine(tarjeta.accept(intereses));
            Console.WriteLine("Caja de ahorro con intereses");
            Console.WriteLine(caja.accept(intereses));
            Console.WriteLine("Cuenta corriente con intereses");
            Console.WriteLine(cuentacorriente.accept(intereses));
        }
    }
}

using System;

namespace juegoInteractivo
{
    class Program
    {
        static void Main(string[] args)
        {
            Personaje p1 = new Personaje((float)1.58,2000,"Albert",75);
            Personaje p2 = p1.copiar();
            p2.setNombre("Carmen");
            Console.WriteLine(p1.getNombre());
            Console.WriteLine(p2.getNombre());


        }
    }
}

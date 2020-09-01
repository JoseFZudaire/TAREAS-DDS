using System;
using System.Linq;

namespace Biblioteca2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            using(DB dataBase = new DB())
            {
                
                Autor unAutor = new Autor(1930,"Argentino Papá","Eze Cohen");
                dataBase.Autores.Add(unAutor);
                dataBase.SaveChanges();

                var cantUsuarios = dataBase.Autores.ToArray();
                Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");



            }
        }
    }
}

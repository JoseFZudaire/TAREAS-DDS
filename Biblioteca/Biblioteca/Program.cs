using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Program
    {

        static void Main(string[] args)
        {
            
            /*DB db = new DB();
            db.Database.Initialize(true);
            */
            /*DateTime fechaJKRowling = new Date(1965, 7, 31);
            Autor jkRowling = new Autor(fechaJKRowling, "Britanica", "J.K.Rowling");

            DateTime fechaMiguelCervantes = new DateTime(1547, 9, 29);
            Autor miguelCervantes = new Autor(fechaMiguelCervantes, "Española", "Miguel Cervantes");

            Libro harryPotter = new Libro(1997, "Novela", "Books for Keeps", jkRowling.idAutor, Estado.EnBiblioteca, "Harry Potter 1", jkRowling);

            Libro donQuijote = new Libro(1605, "Novela", "Francisco de Robles", miguelCervantes.idAutor, Estado.EnReparacion, "Don Quijote de la Mancha", miguelCervantes);

            Lector JZudaire = new Lector("José Zudaire", 12);

            Lector EzeCoen = new Lector("Ezequiel Coen", 0);

            DateTime fechaPrestamo1 = new DateTime(2020, 8, 30);
            Prestamo prestamoZudaire = new Prestamo(15, fechaPrestamo1, harryPotter.idLibro, JZudaire.idLector, JZudaire, harryPotter);

            DateTime fechaPrestamo2 = new DateTime(2020, 7, 30);
            Prestamo prestamoCoen = new Prestamo(15, fechaPrestamo2, donQuijote.idLibro, EzeCoen.idLector, EzeCoen, donQuijote);
            */
            //Autores miguelCervantes = new Autores

            // Construimos un objeto DB para poder realizar las consultas
            // Su ciclo de vida es hasta que finalize el using
            
            using (var context = new DB())
            {
                
                // Podemos consultar por usuarios y posts segun lo definido en la clase DB nuestra
                // Si se fijan no dejan de ser listas asi que respetan todas las funciones de listas que
                // comunmente usamos

                var cantAutores = context.autores.ToArray();
                //  DB db = new DB();
              
                // var cantUsuarios = db.Autores.ToArray();
                Console.WriteLine($"Existen {cantAutores.Length} usuario(s).");

                // Consultemos la cantidad de usuarios creados
                //var cantUsuarios = context.usuarios.ToArray();
                //Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");
                Autor jkRowling = new Autor(1998, "Britanica", "J.K.Rowling");
                Console.WriteLine(jkRowling.nombre);
                // Ahora creemos un usuario
                // Fijense que al definir el ID como autoincremental en la DB, no hace falta setearle alguno.

                //DateTime fechaJKRowling = new DateTime(1965, 7, 31);
                //Autor jkRowling = new Autor(fechaJKRowling, "Britanica", "J.K.Rowling");

                //Autor usuario = new Autor(1965, "Britanica", "J.K.Rowling");
                context.autores.Add(jkRowling);
                context.SaveChanges();
                Console.WriteLine($"Autor {jkRowling.nombre} creado");

                // Lo agrego a la lista de usuarios
                /* context.usuarios.Add(usuario);

                 // Subo los cambios a la DB
                 context.SaveChanges();
                 Console.WriteLine($"Usuario {usuario.nombre} creado");

                 // Consulto nuevamente cantidad de usuarios
                 cantUsuarios = context.usuarios.ToArray();
                 Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");

                 // Ahora quiero borrar a ese usuario
                 var usuarioABorrar = context.usuarios.Single(x => x.nombre == "admin");
                 context.usuarios.Remove(usuarioABorrar);
                 Console.WriteLine($"Usuario {usuarioABorrar.nombre} borrado");
                 context.SaveChanges();

                 // Consulto nuevamente cantidad de usuarios
                 cantUsuarios = context.usuarios.ToArray();
                 Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");

                 // Agrego un usuario con posts
                 var usuarioConPost = new Usuario();
                 usuarioConPost.nombre = "asd123";
                 usuarioConPost.email = "asd123@gmail.com";
                 Post post = new Post();
                 post.texto = "Hola mundo";
                 usuarioConPost.posts = (List<Post>)new List<Post> { post };
                 context.usuarios.Add(usuarioConPost);
                 context.SaveChanges();
                 Console.WriteLine($"Creado post con id {post.id}");

                 // Agrego post al usuario anterior
                 var nuevoPost = new Post();
                 nuevoPost.texto = "Otro post mas";
                 nuevoPost.creador = usuarioConPost;
                 context.posts.Add(nuevoPost);
                 context.SaveChanges();
                 Console.WriteLine($"Creado post con id {nuevoPost.id}");

                 // Consulto los post de este usuario nuevo
                 var usuarioConsultaPost = context.usuarios.Single(x => x.nombre == "asd123");

                 Console.WriteLine($"Post del usuario {usuarioConsultaPost.nombre}:");
                 foreach (Post x in usuarioConsultaPost.posts)
                 {
                     Console.WriteLine($"{x.id} - {x.texto}");
                 }

                 // Vacio tabla
                 context.clear(context.posts);
                 context.clear(context.usuarios);
                 context.SaveChanges();
                 Console.WriteLine("Vaciando la tabla");

             }

             // Evita que se corte la ejecucion del programa
             Console.WriteLine("Finalizo ejecucion, pulsa una tecla para continuar");
             Console.ReadLine();*/



            }
        }
    }
}

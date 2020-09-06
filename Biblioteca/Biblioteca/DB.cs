using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
    public class DB : DbContext
    {
        public DbSet<Autor> autores { get; set; }
        public DbSet<Lector> Lectores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public class DBConnection
        {
            private DBConnection()
            {
            }

            private string databaseName = string.Empty;
            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            public string Password { get; set; }
            private MySqlConnection connection = null;
            public MySqlConnection Connection
            {
                get { return connection; }
            }

            private static DBConnection _instance = null;
            public static DBConnection Instance()
            {
                if (_instance == null)
                    _instance = new DBConnection();
                return _instance;
            }

            public bool IsConnect()
            {
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        return false;
                    string connstring = string.Format("server=localhost;user id=root;database=biblioteca;password=basededatosMATI;persistsecurityinfo=True", databaseName);
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                }

                return true;
            }

            public void Close()
            {
                connection.Close();
            }
        }

        


public DB() : base(nameOrConnectionString: "server=localhost;user id=root;database=biblioteca;password=basededatosMATI;persistsecurityinfo=True")
        {

           /* var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "biblioteca";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                // var cantUsuarios = dbCon.Autores.ToArray();
                // Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");
              
                string query = "SELECT fechaNac,nacionalidad FROM autor";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();


                var cantUsuarios = dbCon.Autores.ToArray();
                
                Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");


                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
               
                //Console.ReadKey();
                dbCon.Close();
        
            }*/


            // Esto setea que es lo que tiene que hacer EntityFramework al conectarse a la DB,
            // en este caso como no queremos que haga sus 'creaciones magicas' le decimos que nada.
            Database.SetInitializer<DB>(null);


            //Database.SetInitializer<DB>(null);
            //DB db = new DB();
            //Database.Initialize(true);
            
            //System.Data.Entity.Database.SetInitializer(new MyInitializer());



        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Definimos que use el schema biblioteca
            modelBuilder.HasDefaultSchema("biblioteca");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>().ToTable("libro", "biblioteca");
            modelBuilder.Entity<Prestamo>().ToTable("prestamo", "biblioteca");
            modelBuilder.Entity<Lector>().ToTable("lector", "biblioteca");
            modelBuilder.Entity<Autor>().ToTable("autor", "biblioteca");

            modelBuilder.Entity<Libro>().HasKey(s => s.idLibro);
            modelBuilder.Entity<Autor>().HasKey(s => s.idAutor);
            modelBuilder.Entity<Lector>().HasKey(s => s.idLector);
            modelBuilder.Entity<Prestamo>().HasKey(s => s.idPrestamo);


            //Libro
            modelBuilder.Entity<Libro>()
                .Property(p => p.idLibro)
                .HasColumnName("idLibro");

            modelBuilder.Entity<Libro>()
                .Property(p => p.anio)
                .HasColumnName("anio");

            modelBuilder.Entity<Libro>()
                .Property(p => p.categoria)
                .HasColumnName("categoria");

            modelBuilder.Entity<Libro>()
                .Property(p => p.editorial)
                .HasColumnName("editorial");

            modelBuilder.Entity<Libro>()
                .Property(p => p.idAutor)
                .HasColumnName("idAutor");

            modelBuilder.Entity<Libro>()
                .Property(p => p.estado)
                .HasColumnName("idEstado");

            //Autor
            modelBuilder.Entity<Autor>()
                .Property(p => p.fechaNac)
                .HasColumnName("fechaNac");

            modelBuilder.Entity<Autor>()
                .Property(p => p.nacionalidad)
                .HasColumnName("nacionalidad");

            modelBuilder.Entity<Autor>()
                .Property(p => p.nombre)
                .HasColumnName("nombre");

            modelBuilder.Entity<Autor>()
                .Property(p => p.idAutor)
                .HasColumnName("idAutor");

            //Lector
            modelBuilder.Entity<Lector>()
                .Property(p => p.idLector)
                .HasColumnName("idLector");

            modelBuilder.Entity<Lector>()
                .Property(p => p.nombre)
                .HasColumnName("nombre");

            modelBuilder.Entity<Lector>()
                .Property(p => p.diasDeMulta)
                .HasColumnName("diasDeMulta");

            //Prestamo
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.cantDias)
                .HasColumnName("cantDias");

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.fechaInicio)
                .HasColumnName("fechaInicio");

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.idPrestamo)
                .HasColumnName("idPrestamo");

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.idLibro)
                .HasColumnName("idLibro");

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.idLector)
                .HasColumnName("idLector");


            modelBuilder.Entity<Prestamo>()
                .HasRequired<Lector>(l => l.lector)
                .WithMany(l => l.prestamos)
                .HasForeignKey(p => p.idLector);

            modelBuilder.Entity<Prestamo>()
                .HasRequired<Libro>(p => p.libro)
                .WithMany(l => l.prestamos)
                .HasForeignKey(p => p.idLibro);

            modelBuilder.Entity<Libro>()
                .HasRequired<Autor>(l => l.autor)
                .WithMany(a => a.libros)
                .HasForeignKey(p => p.idAutor);

        }



    }
}

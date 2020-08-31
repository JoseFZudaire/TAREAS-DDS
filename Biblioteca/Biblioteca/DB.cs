using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class DB : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Lector> Lectores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DB() : base(nameOrConnectionString: "MyContext")
        {

            // Esto setea que es lo que tiene que hacer EntityFramework al conectarse a la DB,
            // en este caso como no queremos que haga sus 'creaciones magicas' le decimos que nada.
            Database.SetInitializer<DB>(null);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Definimos que use el schema biblioteca
            modelBuilder.HasDefaultSchema("biblioteca");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>().ToTable("StudentInfo");
            modelBuilder.Entity<Student>().ToTable("StudentInfo");
            modelBuilder.Entity<Student>().ToTable("StudentInfo");
            modelBuilder.Entity<Student>().ToTable("StudentInfo");

            modelBuilder.Entity<Prestamo>()
                .HasRequired<Lector>(s=>s.idLibro)

            modelBuilder.Entity<x>()
                .HasRequired<Usuario>(s => s.creador)
                .WithMany(g => g.posts)
                .HasForeignKey<int>(s => s.creador_id);

        }



    }
}

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

            modelBuilder.Entity<Libro>().ToTable("libro", "biblioteca");
            modelBuilder.Entity<Prestamo>().ToTable("prestamo", "biblioteca");
            modelBuilder.Entity<Lector>().ToTable("lector", "biblioteca");
            modelBuilder.Entity<Autor>().ToTable("autor", "biblioteca");

            modelBuilder.Entity<Libro>().HasKey(s => s.idLibro);
            modelBuilder.Entity<Autor>().HasKey(s => s.idAutor);
            modelBuilder.Entity<Lector>().HasKey(s => s.idLector);
            modelBuilder.Entity<Prestamo>().HasKey(s => s.idPrestamo);

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

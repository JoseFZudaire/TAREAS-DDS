using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Biblioteca2._0;
using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySql.Data.MySqlClient;

namespace Biblioteca2._0
{
    class DB : DbContext
    {
        public DbSet<Autor> autores { get; set; }
        public DbSet<Lector> Lectores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        // Setea driver y connection string a usar
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Cargar connection strings directamente en el código es peligroso...
            // Solución: http://go.microsoft.com/fwlink/?LinkId=723263
            optionsBuilder.UseMySQL("server=localhost;database=biblioteca;user=root;password=UTNdds1234;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definimos que use el schema public
            //modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>()
                .Property(p => p.idLibro)
                .HasColumnName("idLibro");
            
            modelBuilder.Entity<Libro>()
                .Property(p => p.nombre)
                .HasColumnName("nombre");

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
                .Property(p => p.multadoHasta)
                .HasColumnName("multadoHasta");

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
                .Property(p => p.prestamoActivo)
                .HasColumnName("prestamoActivo");


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
                .HasOne<Lector>(l => l.lector)
                .WithMany(l => l.prestamos)
                .HasForeignKey(p => p.idLector);

            modelBuilder.Entity<Prestamo>()
                .HasOne<Libro>(p => p.libro)
                .WithMany(l => l.prestamos)
                .HasForeignKey(p => p.idLibro);

            modelBuilder.Entity<Libro>()
                .HasOne<Autor>(l => l.autor)
                .WithMany(a => a.libros)
                .HasForeignKey(p => p.idAutor);

        }

        public Libro[] getLibrosDisponibles()
        {
            return Libros.Where(l => l.estado == Estado.EnBiblioteca).ToArray();
        }

        public Lector[] getLectoresDisponibles()
        {
            return Lectores.Where(l=> !(l.multadoHasta != null && DateTime.Now < l.multadoHasta) && l.prestamos.Count() < 3).ToArray();
        }

        public Prestamo[] getPrestamosActivosDe(Lector lec)
        {
            return (Prestamos.Where(p => p.lector == lec && p.prestamoActivo).Include(s => s.libro)).ToArray();
        }
    }
}

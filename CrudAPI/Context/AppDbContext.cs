using CrudAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Context
{
    public class AppDbContext: DbContext //Hacemos la referncia a DbContext
    {
        //Vamos a crear nuestro constructor
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {

        }
        //Añadir entidades
        public DbSet<Empleado> Empleados { get; set; } //Estas son las tablas en mi DB
        public DbSet<Perfil> Perfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Ss va a definir como va estar estructurado mi tabla

            //Iniciamos con Perfil
            modelBuilder.Entity<Perfil>(tb => {
                //Vamos a con el diseno de perfil
                //Nuestra tabla tendra una llave principal, que se encontrara en col.IdPerfil
                tb.HasKey(col => col.IdPerfil);
                //le vamos a agragr una propiedad para la columna col.IdPerfil aumentar uno en uno
                tb.Property(col => col.IdPerfil).UseIdentityColumn().ValueGeneratedOnAdd();
                //ancho maximo de columna 50
                tb.Property(col => col.Nombre).HasMaxLength(50);
                //cambiamos el nombre
                tb.ToTable("Perfil");
                //agrgamos datos
                tb.HasData(
                    new Perfil{IdPerfil = 1, Nombre = "Programador Dev"},
                    new Perfil { IdPerfil = 2, Nombre = "Programador Senior" },
                    new Perfil { IdPerfil = 3, Nombre = "Analista" }
                    );

            });
            //Modificamos la tabla Empleado
            modelBuilder.Entity<Empleado>(tb => {
                //Vamos a con el diseno de perfil
                //Nuestra tabla tendra una llave primarias
                tb.HasKey(col => col.IdEmpleado);
                //le vamos a agragr una propiedad para la columna col.IdPerfil aumentar uno en uno
                tb.Property(col => col.IdEmpleado).UseIdentityColumn().ValueGeneratedOnAdd();
                //ancho maximo de columna 50
                tb.Property(col => col.NombreCompleto).HasMaxLength(50);

                //Vamos a agregar la relacion estre empleado y perfila
                tb.HasOne(col => col.PerfilReferencia).WithMany(p => p.EmpleadosReferencia)
                .HasForeignKey(col => col.IdPerfil);

                //cambiamos el nombre
                tb.ToTable("Empleado");
                

            });
        }
    }
}

using EjemploASP.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploASP.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<TipoEmpleado> TipoEmpleado { get; set; }
        public ApplicationDBcontext()
        {

        }


        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Empleado>(e => e.ToTable("Empleado").HasKey(p=>p.Id));
            modelBuilder.Entity<TipoEmpleado>(entity => entity.ToTable("TipoEmpleado"));
        }
    }
}

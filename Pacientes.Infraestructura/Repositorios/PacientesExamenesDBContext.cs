
using Microsoft.EntityFrameworkCore;
using Pacientes.Dominio.Entidades;
using Pacientes.Infraestructura.Configuraciones;

namespace Pacientes.Infraestructura.Repositorios
{
    public class PacientesExamenesDBContext : DbContext
    {
        public PacientesExamenesDBContext(DbContextOptions<PacientesExamenesDBContext> options)
            : base(options) { }

        public DbSet<ReporteExamenesPaciente> ReporteExamenesPacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReporteExamenesPacienteConfiguracion());
        }
    }
}

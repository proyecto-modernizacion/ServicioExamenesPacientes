using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacientes.Dominio.Entidades;

namespace Pacientes.Infraestructura.Configuraciones
{
    public class ReporteExamenesPacienteConfiguracion: IEntityTypeConfiguration<ReporteExamenesPaciente>
    {
        public void Configure(EntityTypeBuilder<ReporteExamenesPaciente> builder)
        {
            builder.HasNoKey();
        }
    }
}

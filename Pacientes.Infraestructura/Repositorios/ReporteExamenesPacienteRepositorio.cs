using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pacientes.Dominio.Entidades;
using Pacientes.Dominio.Puertos.Repositorios;

namespace Pacientes.Infraestructura.Repositorios
{
    public class ReporteExamenesPacienteRepositorio: IReporteExamenesPacienteRepositorio
    {
        private readonly IServiceProvider _serviceProvider;

        public ReporteExamenesPacienteRepositorio(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private PacientesExamenesDBContext GetContext()
        {
            return _serviceProvider.GetService<PacientesExamenesDBContext>();
        }

        public async Task<List<ReporteExamenesPaciente>> ObtenerReporteExamenesPorPaciente(string? p_paciente_cod = "", DateOnly? p_fechainicio = default, string? p_numdoc = "")
        {
            var ctx = GetContext();
            var reporte = await ctx.ReporteExamenesPacientes.FromSqlRaw("SELECT * FROM fun_examenesporpaciente({0},{1},{2})"
                    , p_paciente_cod
                    , p_fechainicio
                    , p_numdoc)
                .ToListAsync();

            await ctx.DisposeAsync();
            return reporte;
        }
    }
}

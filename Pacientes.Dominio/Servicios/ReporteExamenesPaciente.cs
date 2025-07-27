using Pacientes.Dominio.Puertos.Repositorios;

namespace Pacientes.Dominio.Servicios
{
    public class ReporteExamenesPaciente(IReporteExamenesPacienteRepositorio reporteExamenesPacienteRepositorio)
    {
        private readonly IReporteExamenesPacienteRepositorio _reporteExamenesPacienteRepositorio = reporteExamenesPacienteRepositorio;
        public async Task<List<Entidades.ReporteExamenesPaciente>> ObtenerReporteExamenesPorPaciente(
            string? pacienteCod, DateOnly? fechaInicio, string? nodoc)
        {
            return await _reporteExamenesPacienteRepositorio.ObtenerReporteExamenesPorPaciente(pacienteCod, fechaInicio, nodoc);
        }
    }
}

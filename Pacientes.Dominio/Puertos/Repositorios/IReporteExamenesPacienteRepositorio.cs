using Pacientes.Dominio.Entidades;

namespace Pacientes.Dominio.Puertos.Repositorios
{
    public interface IReporteExamenesPacienteRepositorio
    {
        Task<List<ReporteExamenesPaciente>> ObtenerReporteExamenesPorPaciente(
            string? pacienteCod, DateOnly? fechaInicio, string? nit);
    }
}

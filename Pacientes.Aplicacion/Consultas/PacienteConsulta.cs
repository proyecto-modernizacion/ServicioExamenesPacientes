using MediatR;
using Pacientes.Aplicacion.Dto;

namespace Pacientes.Aplicacion.Consultas
{
    public record ExamenesPacientesConsulta() : IRequest<ReporteExamenesPacienteOutList>;
    public record ReporteExamenesPacientesConsulta(
        string? p_paciente_cod,
        DateOnly? p_fechainicio,
        string? p_numdoc) : IRequest<ReporteExamenesPacienteOutList>;
}

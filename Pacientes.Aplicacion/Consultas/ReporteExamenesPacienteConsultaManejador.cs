using MediatR;
using Pacientes.Aplicacion.Dto;
using Pacientes.Aplicacion.Consultas;
using AutoMapper;
using Pacientes.Dominio.Servicios;
using Pacientes.Aplicacion.Enum;
using System.Net;

namespace Pacientes.Aplicacion.Consultas
{
    public class ReporteExamenesPacienteConsultaManejador : IRequestHandler<ReporteExamenesPacientesConsulta, ReporteExamenesPacienteOutList>
    {
        private readonly IMapper _mapper;
        private readonly ReporteExamenesPaciente _servicoReporte;

        public ReporteExamenesPacienteConsultaManejador(IMapper mapper, ReporteExamenesPaciente servicoReporte)
        {
            _mapper = mapper;
            _servicoReporte = servicoReporte;
        }

        public async Task<ReporteExamenesPacienteOutList> Handle(ReporteExamenesPacientesConsulta request, CancellationToken cancellationToken)
        {
            ReporteExamenesPacienteOutList output = new()
            {
                reporteExamenesPaciente = []
            };

            try
            {
                var reportePacientes = await _servicoReporte.ObtenerReporteExamenesPorPaciente(request.p_paciente_cod, request.p_fechainicio, request.p_numdoc);

                if (reportePacientes.Count > 0)
                {
                    output.reporteExamenesPaciente = _mapper.Map<List<ReporteExamenesPacienteDto>>(reportePacientes);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
                    output.Status = HttpStatusCode.OK;
                }
                else
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron registros";
                    output.Status = HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }
            return output;
        }
    }
}

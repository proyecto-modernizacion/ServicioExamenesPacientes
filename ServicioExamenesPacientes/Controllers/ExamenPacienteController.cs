using Microsoft.AspNetCore.Mvc;
using Pacientes.Aplicacion.Consultas;
using Pacientes.Aplicacion.Dto;
using Pacientes.Aplicacion.Enum;
using Pacientes.Infraestructura.Repositorios;

namespace ServicioExamenesPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ExamenPacienteController : ControllerBase
    {
        private readonly ReporteExamenesPacienteConsultaManejador _consultaManejador;

        public ExamenPacienteController(ReporteExamenesPacienteConsultaManejador consultaManejador)
        {
            _consultaManejador = consultaManejador;
        }

        /// <summary>
        /// Obtiene un reporte de examenes por paciente
        /// </summary>
        /// <response code="200"> 
        /// </response>
        [HttpPost]
        [Route("ReporteExamenesPacientes")]
        [ProducesResponseType(typeof(ReporteExamenesPacienteRepositorio), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ReporteExamenesPacientes([FromBody] ReporteExamenesPacientesConsulta input)
        {
            var output = await _consultaManejador.Handle(input, CancellationToken.None);

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }
    }
}

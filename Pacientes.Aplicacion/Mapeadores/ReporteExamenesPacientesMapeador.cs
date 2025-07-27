using AutoMapper;
using Pacientes.Aplicacion.Dto;

namespace Pacientes.Aplicacion.Mapeadores
{
    public class ReporteExamenesPacientesMapeador: Profile
    {
        public ReporteExamenesPacientesMapeador()
        {
            CreateMap<Dominio.Entidades.ReporteExamenesPaciente, ReporteExamenesPacienteDto>().ReverseMap();
        }
    }
}

namespace Pacientes.Aplicacion.Dto
{
    public class ReporteExamenesPacienteDto
    {
        public string? examen { get; set; }
        public string? nombre { get; set; }
        public int? reg_exa { get; set; }
        public bool? contestado { get; set; }
        public bool? validado { get; set; }
        public bool? modificado { get; set; }
        public bool? val_parcial { get; set; }
        public DateOnly? fec_val { get; set; }
        public DateOnly? fec_res { get; set; }
        public DateOnly? fec_mod { get; set; }
        public DateOnly? fec_val_parcial { get; set; }
        public string? analito_cod { get; set; }
    }

    public class  ReporteExamenesPacienteOut: BaseOut
    {
        public ReporteExamenesPacienteDto ReporteExamenesPacienteDto { get; set; }
    }

    public class ReporteExamenesPacienteOutList : BaseOut
    {
        public List<ReporteExamenesPacienteDto> reporteExamenesPaciente { get; set; }
    }
}

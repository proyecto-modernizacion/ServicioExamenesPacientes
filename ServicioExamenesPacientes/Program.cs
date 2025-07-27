using Microsoft.EntityFrameworkCore;
using Pacientes.Aplicacion.Consultas;
using Pacientes.Dominio.Puertos.Repositorios;
using Pacientes.Dominio.Servicios;
using Pacientes.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<PacientesExamenesDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient<IReporteExamenesPacienteRepositorio, ReporteExamenesPacienteRepositorio>();
builder.Services.AddTransient<ReporteExamenesPaciente>();
builder.Services.AddScoped<ExamenesPacientesConsulta>();
builder.Services.AddScoped<ReporteExamenesPacienteConsultaManejador>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

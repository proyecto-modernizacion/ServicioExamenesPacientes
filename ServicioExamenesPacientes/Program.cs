using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pacientes.Aplicacion.Clientes;
using Pacientes.Aplicacion.Consultas;
using Pacientes.Dominio.Puertos.Repositorios;
using Pacientes.Dominio.Servicios;
using Pacientes.Infraestructura.Repositorios;
using ServicioExamenesPacientes.Middleware;

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
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            Array.Empty<string>()
            }
        });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<PacientesExamenesDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient<IReporteExamenesPacienteRepositorio, ReporteExamenesPacienteRepositorio>();
builder.Services.AddTransient<ReporteExamenesPaciente>();
builder.Services.AddScoped<ExamenesPacientesConsulta>();
builder.Services.AddScoped<ReporteExamenesPacienteConsultaManejador>();

builder.Services.AddHttpClient<IUsuarioApiClient, UsuarioApiClient>(client =>
{
    client.BaseAddress = new Uri("https://usuarios-288929002151.us-central1.run.app/");
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<AutorizadorMiddleware>();
app.MapControllers();

await app.RunAsync();

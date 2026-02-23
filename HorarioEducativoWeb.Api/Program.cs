using Microsoft.EntityFrameworkCore;
using HorarioEducativoWeb.API.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar soporte para Controladores (Indispensable para ScheduleController)
builder.Services.AddControllers();

// 2. Configurar Swagger/OpenAPI para probar el API fácilmente
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configurar la Base de Datos SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Configurar CORS (Para que Blazor pueda comunicarse con el API)
builder.Services.AddCors(policy => policy.AddPolicy("BlazorPolicy", opt =>
    opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// 5. Configurar el pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto permite entrar a /swagger para probar
}

app.UseHttpsRedirection();

// 6. Activar la política de CORS
app.UseCors("BlazorPolicy");

app.UseAuthorization();

// 7. Mapear los controladores
app.MapControllers();

app.Run();
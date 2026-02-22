using HorarioEducativoWeb.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HorarioEducativoWeb.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Horario> Horarios => Set<Horario>();
        public DbSet<Docente> Docentes => Set<Docente>();
        public DbSet<Asignatura> Asignaturas => Set<Asignatura>();
        public DbSet<Aula> Aulas => Set<Aula>();
        public DbSet<Grupo> Grupos => Set<Grupo>();
        public DbSet<CentroEducativo> InformacionCentro => Set<CentroEducativo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seed para Información del Centro (¡Aquí está!)
            modelBuilder.Entity<CentroEducativo>().HasData(
                new CentroEducativo
                {
                    Id = 1,
                    Nombre = "Centro Educativo Central",
                    Direccion = "Av. Principal #123, Ciudad Educativa",
                    RNC = "101-00000-1"
                }
            );

            // 2. Seed para Docentes
            modelBuilder.Entity<Docente>().HasData(
                new Docente { Id = 1, Nombre = "Juan Pérez", Especialidad = "Matemáticas" },
                new Docente { Id = 2, Nombre = "María García", Especialidad = "Programación" }
            );

            // 3. Seed para Asignaturas
            modelBuilder.Entity<Asignatura>().HasData(
                new Asignatura { Id = 1, Nombre = "Álgebra Lineal", HorasSemanales = 4 },
                new Asignatura { Id = 2, Nombre = "Desarrollo Web con .NET", HorasSemanales = 6 }
            );

            // 4. Seed para Aulas
            modelBuilder.Entity<Aula>().HasData(
                new Aula { Id = 1, Codigo = "Lab-101" },
                new Aula { Id = 2, Codigo = "Aula-202" }
            );

            // 5. Seed para Grupos
            modelBuilder.Entity<Grupo>().HasData(
                new Grupo { Id = 1, Nombre = "4to de Media", Modalidad = "Media" }
            );

            // 6. Seed para Horario inicial
            modelBuilder.Entity<Horario>().HasData(
                new Horario
                {
                    Id = 1,
                    DocenteId = 1,
                    AsignaturaId = 1,
                    AulaId = 1,
                    GrupoId = 1,
                    DiaSemana = "Lunes",
                    HoraInicio = new TimeSpan(8, 0, 0),
                    HoraFin = new TimeSpan(10, 0, 0)
                }
            );
        }
    }
}
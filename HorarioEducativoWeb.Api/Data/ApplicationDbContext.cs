using HorarioEducativoWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HorarioEducativoWeb.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Horario> Horarios { get; set; }

        // Ajustado para que coincida con la lógica de "información única"
        public DbSet<CentroEducativo> InformacionCentro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seed para Información del Centro
            // Importante: El Id debe ser 1 para que nuestra lógica de "Update" lo encuentre siempre
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
                new Grupo { Id = 1, Nombre = "4to de Media", Modalidad = "Técnico en Informática" }
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

            // Configuraciones Adicionales (Opcional pero recomendado)
            // Esto asegura que si borras un aula, no se rompa todo de golpe si hay horarios
            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Docente)
                .WithMany()
                .HasForeignKey(h => h.DocenteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
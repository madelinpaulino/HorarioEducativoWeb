using System.ComponentModel.DataAnnotations;

namespace HorarioEducativoWeb.Api.Models
{
    public class CentroEducativo
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = "Centro Educativo Central";
        public string Direccion { get; set; } = "Av. Principal #123";
        public string RNC { get; set; } = "101-00000-1";
    }

    public class Docente
    {
        [Key] public int Id { get; set; }
        [Required] public string Nombre { get; set; } = "";
        public string Especialidad { get; set; } = "";
    }

    public class Asignatura
    {
        [Key] public int Id { get; set; }
        [Required] public string Nombre { get; set; } = "";
        public int HorasSemanales { get; set; } // Requisito: Cantidad de horas
    }

    public class Grupo
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = ""; // Ej: 4to de Media
        public string Modalidad { get; set; } = ""; // Requisito: Inicial, Primaria, Media, Universitario
    }

    public class Aula
    {
        [Key] public int Id { get; set; }
        public string Codigo { get; set; } = "";
    }

    public class Horario
    {
        [Key] public int Id { get; set; }
        public int DocenteId { get; set; }
        public int AsignaturaId { get; set; }
        public int AulaId { get; set; }
        public int GrupoId { get; set; }
        public string DiaSemana { get; set; } = "";
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public Docente? Docente { get; set; }
        public Asignatura? Asignatura { get; set; }
        public Aula? Aula { get; set; }
        public Grupo? Grupo { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HorarioEducativoWeb.Shared.Models
{
    public class CentroEducativo
    {
        [Key] public int Id { get; set; }
        [Required] public string Nombre { get; set; } = "Centro Educativo Central";
        public string Direccion { get; set; } = "Av. Principal #123";
        public string RNC { get; set; } = "101-00000-1";
    }

    public class Docente
    {
        [Key] public int Id { get; set; }
        [Required] public string Nombre { get; set; } = "";
        public string Especialidad { get; set; } = "";
        [JsonIgnore] public virtual ICollection<Horario>? Horarios { get; set; }
    }

    public class Asignatura
    {
        [Key] public int Id { get; set; }
        [Required] public string Nombre { get; set; } = "";
        public int HorasSemanales { get; set; }
        [JsonIgnore] public virtual ICollection<Horario>? Horarios { get; set; }
    }

    public class Grupo
    {
        [Key] public int Id { get; set; }
        [Required] public string Nombre { get; set; } = "";
        [Required] public string Modalidad { get; set; } = "";
        [JsonIgnore] public virtual ICollection<Horario>? Horarios { get; set; }
    }

    public class Aula
    {
        [Key] public int Id { get; set; }
        [Required] public string Codigo { get; set; } = "";
        [JsonIgnore] public virtual ICollection<Horario>? Horarios { get; set; }
    }

    public class Horario
    {
        [Key] public int Id { get; set; }

        [Required] public int DocenteId { get; set; }
        [ForeignKey("DocenteId")] public virtual Docente? Docente { get; set; }

        [Required] public int AsignaturaId { get; set; }
        [ForeignKey("AsignaturaId")] public virtual Asignatura? Asignatura { get; set; }

        [Required] public int AulaId { get; set; }
        [ForeignKey("AulaId")] public virtual Aula? Aula { get; set; }

        [Required] public int GrupoId { get; set; }
        [ForeignKey("GrupoId")] public virtual Grupo? Grupo { get; set; }

        [Required] public string DiaSemana { get; set; } = "";
        [Required] public TimeSpan HoraInicio { get; set; }
        [Required] public TimeSpan HoraFin { get; set; }
    }
}
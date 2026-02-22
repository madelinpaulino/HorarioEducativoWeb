namespace HorarioEducativoWeb.API.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public int DocenteId { get; set; }
        public int AsignaturaId { get; set; }
        public int AulaId { get; set; }
        public int GrupoId { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public Docente? Docente { get; set; }
        public Asignatura? Asignatura { get; set; }
        public Aula? Aula { get; set; }
        public Grupo? Grupo { get; set; }
    }

    // Clases de apoyo necesarias para que la navegación funcione
    public class Docente { public int Id { get; set; } public string Nombre { get; set; } = ""; }
    public class Asignatura { public int Id { get; set; } public string Nombre { get; set; } = ""; }
    public class Aula { public int Id { get; set; } public string Codigo { get; set; } = ""; }
    public class Grupo { public int Id { get; set; } public string Nombre { get; set; } = ""; }
}
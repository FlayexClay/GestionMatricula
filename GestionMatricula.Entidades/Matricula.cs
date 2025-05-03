using System;
using System.Collections.Generic;

namespace GestionMatricula.Entidades.Contexto;

public partial class Matricula
{
    public int Id { get; set; }

    public int AlumnoId { get; set; }

    public int CursoId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaMatricula { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Curso Curso { get; set; } = null!;
}

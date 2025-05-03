using System;
using System.Collections.Generic;

namespace GestionMatricula.Entidades.Contexto;

public partial class Alumno
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}

using System;
using System.Collections.Generic;

namespace GestionMatricula.Entidades.Contexto;

public partial class Curso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}

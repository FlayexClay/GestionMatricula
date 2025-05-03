using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMatricula.Dto
{
    public class MatriculaDto
    {
        public int Id { get; set; }
        [Required]
        public int AlumnoId { get; set; }
        public string AlumnoNombre { get; set; } = null!;
        [Required]
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = null!;
        public string Estado { get; set; }
       
        public DateTime FechaMatricula { get; set; }
    }
}

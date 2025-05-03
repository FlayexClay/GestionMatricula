using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMatricula.Dto;

namespace GestionMatricula.Servicio.Interfaces
{
    public interface ICursoService
    {
        Task CrearCursoAsync(CursoDto cursoDto);
        Task ActualizarCursoAsync(int cursoId, CursoDto cursoDto);
        Task<CursoDto> ObtenerCursoPorIdAsync(int cursoId);
        Task EliminarCursoAsync(int cursoId);
        Task<IEnumerable<CursoDto>> ObtenerTodosLosCursosAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMatricula.Dto;

namespace GestionMatricula.Servicio.Interfaces
{
    public interface IMatriculaService
    {
        Task CrearMatriculaAsync(MatriculaDto matriculaDto);
        Task ActualizarEstadoMatriculaAsync(int id, string estado);
        Task EliminarMatriculaAsync(int id);
        Task<MatriculaDto> ObtenerMatriculaPorIdAsync(int id);
        Task<IEnumerable<MatriculaDto>> ObtenerMatriculasPorAlumnoIdAsync(int alumnoId);
        Task<IEnumerable<MatriculaDto>> ObtenerMatriculasPorEstadoAsync(string estado);
        Task<IEnumerable<MatriculaDto>> ObtenerTodasLasMatriculasAsync();
    }
}

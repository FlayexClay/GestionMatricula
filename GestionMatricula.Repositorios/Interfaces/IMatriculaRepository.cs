using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMatricula.Entidades.Contexto;

namespace GestionMatricula.Repositorios.Interfaces
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        Task<bool> IsMatriculaDuplicada(int alumnoId, int cursoId);  
        Task<IEnumerable<Matricula>> GetMatriculasByEstadoAsync(string estado);  
        Task<Matricula> GetMatriculaByAlumnoAndCursoAsync(int alumnoId, int cursoId);
        Task<IEnumerable<Matricula>> ObtenerMatriculasPorAlumnoIdAsync(int alumnoId);
        Task<IEnumerable<Matricula>> GetMatriculasByCursoIdAsync(int cursoId);
        Task<IEnumerable<Matricula>> ObtenerMatriculasConAlumnosYCursosAsync();
    }
}

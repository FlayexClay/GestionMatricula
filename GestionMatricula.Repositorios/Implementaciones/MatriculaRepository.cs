using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMatricula.AccesoDatos.Contexto;
using GestionMatricula.Entidades.Contexto;
using GestionMatricula.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionMatricula.Repositorios.Implementaciones
{
    public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
    {

        private readonly BdGestionContext _context;

        public MatriculaRepository(BdGestionContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task<bool> IsMatriculaDuplicada(int alumnoId, int cursoId)
        {
            return await _context.Matriculas
                .AnyAsync(m => m.AlumnoId == alumnoId && m.CursoId == cursoId);

        }

        public async Task<IEnumerable<Matricula>> GetMatriculasByEstadoAsync(string estado)
        { 
            return await _context.Matriculas
                .Where(m => m.Estado == estado)
                .ToListAsync();
        }

        public async Task<Matricula> GetMatriculaByAlumnoAndCursoAsync(int alumnoId, int cursoId)
        {
            return await _context.Matriculas
                       .FirstOrDefaultAsync(m => m.AlumnoId == alumnoId && m.CursoId == cursoId);
        }

        public async Task<IEnumerable<Matricula>> ObtenerMatriculasPorAlumnoIdAsync(int alumnoId)
        {
            return await _context.Matriculas
                         .Include(m => m.Alumno)  // Incluir la entidad Alumno
                         .Include(m => m.Curso)   // Incluir la entidad Curso
                         .Where(m => m.AlumnoId == alumnoId)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Matricula>> GetMatriculasByCursoIdAsync(int cursoId)
        {
            return await _context.Matriculas
                                 .Where(m => m.CursoId == cursoId)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Matricula>> ObtenerMatriculasConAlumnosYCursosAsync()
        {
            return await _context.Matriculas
                .Include(m => m.Alumno)  // Incluir la entidad Alumno
                .Include(m => m.Curso)   // Incluir la entidad Curso
                .ToListAsync();  // Ejecuta la consulta y obtiene las matrículas con sus relaciones
        }
    }
}

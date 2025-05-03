using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionMatricula.Dto;
using GestionMatricula.Entidades.Contexto;
using GestionMatricula.Repositorios.Interfaces;
using GestionMatricula.Servicio.Interfaces;

namespace GestionMatricula.Servicio.Implementaciones
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;
        private readonly IMatriculaRepository _matriculaRepository;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper, IMatriculaRepository matriculaRepository)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
            _matriculaRepository = matriculaRepository;
        }

        public async Task CrearCursoAsync(CursoDto cursoDto)
        {
            try
            {
                var curso = _mapper.Map<Curso>(cursoDto);
                await _cursoRepository.AddAsync(curso);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al crear el curso.", ex);
            }
        }

        public async Task ActualizarCursoAsync(int cursoId, CursoDto cursoDto)
        {
            try
            {
                var curso = await _cursoRepository.GetByIdAsync(cursoId);
                if (curso == null) throw new KeyNotFoundException("El curso no existe.");

                _mapper.Map(cursoDto, curso);
                await _cursoRepository.UpdateAsync(curso);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el curso.", ex);
            }
        }

        public async Task<CursoDto> ObtenerCursoPorIdAsync(int cursoId)
        {
            try
            {
                var curso = await _cursoRepository.GetByIdAsync(cursoId);
                if(curso == null) throw new KeyNotFoundException("El curso no existe.");

                return _mapper.Map<CursoDto>(curso);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el curso.", ex);
            }
        }

        public async Task EliminarCursoAsync(int cursoId)
        {
            try
            {
                var curso = await _cursoRepository.GetByIdAsync(cursoId);
                if(curso == null) throw new KeyNotFoundException("El curso no existe.");

                var matriculas = await _matriculaRepository.GetMatriculasByCursoIdAsync(cursoId);
                if (matriculas.Any()) throw new InvalidOperationException("No se puede eliminar un curso que tiene matriculados.");
                
                await _cursoRepository.DeleteAsync(cursoId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar el curso.", ex);
            }
        }

        
        public async Task<IEnumerable<CursoDto>> ObtenerTodosLosCursosAsync()
        {
            try
            {               
                var cursos = await _cursoRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<CursoDto>>(cursos);
            }
            catch (Exception ex)
            {                
                throw new InvalidOperationException("Error al obtener los cursos.", ex);
            }
        }
    }
}

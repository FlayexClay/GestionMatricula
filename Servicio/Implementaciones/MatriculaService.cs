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
    public class MatriculaService : IMatriculaService 
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public MatriculaService( IMatriculaRepository matriculaRepository,
                                 IAlumnoRepository alumnoRepository,
                                 ICursoRepository cursoRepository,
                                 IMapper mapper) 
        {
        
            _matriculaRepository = matriculaRepository;
            _alumnoRepository = alumnoRepository;
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task CrearMatriculaAsync(MatriculaDto matriculaDto)
        {
            try
            {
                var alumno = await _alumnoRepository.GetByIdAsync(matriculaDto.AlumnoId);
                if (alumno == null) throw new ArgumentException("El estudianmte no existe");

                var curso = await _cursoRepository.GetByIdAsync(matriculaDto.CursoId);
                if (curso == null) throw new ArgumentException("El curso no existe");

                bool isDuplicada = await _matriculaRepository.IsMatriculaDuplicada(matriculaDto.AlumnoId, matriculaDto.CursoId);
                if (isDuplicada) throw new InvalidOperationException("El estudiante ya esta matriculado en el curso");

                var matricula = new Matricula
                {
                    AlumnoId = matriculaDto.AlumnoId,
                    CursoId = matriculaDto.CursoId,
                    Estado = "Activa",
                    FechaMatricula = DateTime.Now
                };

                await _matriculaRepository.AddAsync(matricula);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al crear la matricula", ex);
            }
        }

        public async Task ActualizarEstadoMatriculaAsync(int id, string estado)
        {
            try
            {
                var matricula = await _matriculaRepository.GetByIdAsync(id);
                if(matricula == null) throw new KeyNotFoundException("La matricula no existe.");

                if (matricula.Estado == "Finalizada" && estado == "Cancelada") throw new InvalidOperationException("No se puede cambiar el estado a 'Cancelada' si ya 'Finalizada'");


                matricula.Estado = estado;

                await _matriculaRepository.UpdateAsync(matricula);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el estado de la matricula.", ex);
            }
        }

        public async Task EliminarMatriculaAsync(int id)
        {
            try
            {
                var matricula = await _matriculaRepository.GetByIdAsync(id);
                if(matricula == null) throw new KeyNotFoundException("La matricula no existe.");

                if (matricula.Estado != "Cancelada") throw new InvalidOperationException("Solo se puede eliminar una matricula si se estado es 'Cancelada'.");


                await _matriculaRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error al eliminar la matricula.", ex);
            }
        }

        public async Task<MatriculaDto> ObtenerMatriculaPorIdAsync(int id)
        {
            try
            {
                var matricula = await _matriculaRepository.GetByIdAsync(id);
                if(matricula == null) throw new KeyNotFoundException("La matricula no existe.");

                return _mapper.Map<MatriculaDto>(matricula);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error al obtener la matricula.", ex);
            }
        }

        public async Task<IEnumerable<MatriculaDto>> ObtenerMatriculasPorAlumnoIdAsync(int alumnoId)
        {
            try
            {
                // Llamamos al repositorio para obtener las matrículas con las entidades Alumno y Curso
                var matriculas = await _matriculaRepository.ObtenerMatriculasPorAlumnoIdAsync(alumnoId);

                // Mapear las matrículas a DTOs
                return _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener las matrículas por ID de alumno.", ex);
            }
        }

        public async Task<IEnumerable<MatriculaDto>> ObtenerMatriculasPorEstadoAsync(string estado)
        {
            try
            {
                var matriculas = await _matriculaRepository.GetMatriculasByEstadoAsync(estado);
                return _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener matriculas por estado.", ex);
            }
        }

        public async Task<IEnumerable<MatriculaDto>> ObtenerTodasLasMatriculasAsync()
        {
            var matriculas = await _matriculaRepository.ObtenerMatriculasConAlumnosYCursosAsync();
            return _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
        }
    }
}

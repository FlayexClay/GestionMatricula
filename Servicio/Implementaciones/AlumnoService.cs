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
    public class AlumnoService : IAlumnoService
    {
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IMapper _mapper;

        public AlumnoService(IAlumnoRepository alumnoRepository, IMapper mapper)
        {
            _alumnoRepository = alumnoRepository;
            _mapper = mapper;
        }

        public async Task CrearAlumnoAsync(AlumnoDto alumnoDto)
        {
            try
            {
                var alumno = _mapper.Map<Alumno>(alumnoDto);

                await _alumnoRepository.AddAsync(alumno);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al crear el alumno.", ex);
            }
        }

        public async Task ActualizarAlumnoAsync(int alumnoId, AlumnoDto alumnoDto)
        {
            try
            {
                var alumno = await _alumnoRepository.GetByIdAsync(alumnoId);
                if(alumno == null) throw new KeyNotFoundException("El alumno no existe.");

                _mapper.Map(alumnoDto, alumno);

                await _alumnoRepository.UpdateAsync(alumno);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el alumno.", ex);
            }
        }

        public async Task<AlumnoDto> ObtenerAlumnoPorIdAsync(int alumnoId)
        {
            try
            {
                var alumno = await _alumnoRepository.GetByIdAsync(alumnoId);
                if(alumno == null) throw new KeyNotFoundException("El alumno no existe.");

                return _mapper.Map<AlumnoDto>(alumno);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el alumno.", ex);
            }
        }

        public async Task<IEnumerable<AlumnoDto>> ObtenerTodosLosAlumnosAsync()
        {
            try
            {
                var alumnos = await _alumnoRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<AlumnoDto>>(alumnos);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error al obtener todos los alumnos.", ex);
            }
        }

        public async Task EliminarAlumnoAsync(int alumnoId)
        {
            try
            {
                var alumno = await _alumnoRepository.GetByIdAsync(alumnoId);
                if(alumno == null) throw new KeyNotFoundException("El alumno no existe.");

                await _alumnoRepository.DeleteAsync(alumnoId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al elminar el alumno", ex);
            }        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMatricula.Dto;

namespace GestionMatricula.Servicio.Interfaces
{
    public interface IAlumnoService
    {
        Task CrearAlumnoAsync(AlumnoDto alumnoDto);
        Task ActualizarAlumnoAsync(int alumnoId, AlumnoDto alumnoDto);
        Task<AlumnoDto> ObtenerAlumnoPorIdAsync(int alumnoId);
        Task<IEnumerable<AlumnoDto>> ObtenerTodosLosAlumnosAsync();
        Task EliminarAlumnoAsync(int alumnoId);
    }
}

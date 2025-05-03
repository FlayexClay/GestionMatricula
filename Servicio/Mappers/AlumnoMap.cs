using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionMatricula.Dto;
using GestionMatricula.Entidades.Contexto;

namespace GestionMatricula.Servicio.Mappers
{
    public class AlumnoMap : Profile
    {
        public AlumnoMap()
        {
            CreateMap<Alumno, AlumnoDto>();
            CreateMap<AlumnoDto, Alumno>();
        }
    }
}

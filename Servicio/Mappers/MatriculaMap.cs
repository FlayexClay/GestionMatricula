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
    public class MatriculaMap : Profile
    {
        public MatriculaMap()
        {
            CreateMap<Matricula, MatriculaDto>()
                .ForMember(dest => dest.AlumnoNombre, opt => opt.MapFrom(src => src.Alumno.Nombre))
                .ForMember(dest => dest.CursoNombre, opt => opt.MapFrom(src => src.Curso.Nombre));

            CreateMap<MatriculaDto, Matricula>()
                .ForMember(dest => dest.Alumno, opt => opt.MapFrom(src => new Alumno { Id = src.AlumnoId }))
                .ForMember(dest => dest.Curso, opt => opt.MapFrom(src => new Curso { Id = src.CursoId }))
                .ForMember(dest => dest.FechaMatricula, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}

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
    public class CursoMap : Profile
    {
        public CursoMap()
        { 
            CreateMap<Curso, CursoDto>();
            CreateMap<CursoDto, Curso>();
        }
    }
}

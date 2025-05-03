using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMatricula.AccesoDatos.Contexto;
using GestionMatricula.Entidades.Contexto;
using GestionMatricula.Repositorios.Interfaces;

namespace GestionMatricula.Repositorios.Implementaciones
{
    public class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
    {
        private readonly BdGestionContext _context;
        public AlumnoRepository(BdGestionContext context) : base(context) 
        { 
            _context = context;
        }
    }
}

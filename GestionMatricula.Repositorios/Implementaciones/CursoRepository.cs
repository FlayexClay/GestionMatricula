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
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {

        private readonly BdGestionContext _context;
        public CursoRepository(BdGestionContext context) : base(context)
        {
            _context = context;
        }
    }
}

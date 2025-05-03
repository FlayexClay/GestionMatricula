using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMatricula.AccesoDatos.Contexto;
using GestionMatricula.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionMatricula.Repositorios.Implementaciones
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BdGestionContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(BdGestionContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();   
        }

        public async Task AddAsync(T entity)
        { 
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        { 
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

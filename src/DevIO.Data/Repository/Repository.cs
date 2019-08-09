using DevIO.Business.Models;
using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public abstract class Repository<TJames> : IRepository<TJames> where TJames : Entity, new()
    {
        protected readonly MyDbContext _db;
        protected readonly DbSet<TJames> _dbSet;

        public Repository(MyDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TJames>();
        }

        public virtual async Task Adicionar(TJames entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TJames entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();

        }

        public async Task<IEnumerable<TJames>> Buscar(Expression<Func<TJames, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }


        public virtual async Task<List<TJames>> ObterAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TJames> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task Remover(Guid id)
        {
            new TJames();
            // _dbSet.Remove(await ObterPorId(id)); //Tem que buscar no banco :(
            _dbSet.Remove(new TJames { ID = id }); // Sem buscar no banco \o/
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }


        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}

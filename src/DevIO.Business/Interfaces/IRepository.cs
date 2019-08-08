using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IRepository<TCoiso> : IDisposable where TCoiso : Entity
    {
        Task Adicionar(TCoiso entity);
        Task<TCoiso> ObterPorId(Guid id);
        Task<List<TCoiso>> ObterAll();
        Task Atualizar(TCoiso entity);
        Task Remover(Guid id);
        Task<IEnumerable<TCoiso>> Buscar(Expression<Func<TCoiso, bool>> predicate);
        Task<int> SaveChanges();

    }
}

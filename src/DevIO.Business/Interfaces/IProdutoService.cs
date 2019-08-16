using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.App.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
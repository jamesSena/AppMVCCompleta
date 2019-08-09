using AppMVC.Models;
using DevIO.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

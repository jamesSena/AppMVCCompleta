using AppMVC.Models;
using DevIO.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public Task<IEnumerable<Endereco>> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            throw new NotImplementedException();
        }
    }
}

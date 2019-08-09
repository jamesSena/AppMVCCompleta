using AppMVC.Models;
using DevIO.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DevIO.Data.Context;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(MyDbContext myDbContext) :base(myDbContext){}

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            //Inclui o Fornecedor e pega o "primeiro/unico" produto com esse ID.
            return await _db.Produtos.AsNoTracking().Include(f => f.Fornecedor).FirstOrDefaultAsync(p => p.ID == id); 
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedor()
        {
            // Inclui o Fornecedor e retorna todos os produtos e fornecedores associados a esses produtos 
            return await _db.Produtos.AsNoTracking().Include(f => f.Fornecedor).OrderBy(p=>p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            // Retorna uma lista de produtos que tem esse fornecedor.
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}

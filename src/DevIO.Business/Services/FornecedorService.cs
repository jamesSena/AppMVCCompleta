using DevIO.App.Interfaces;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class FonercedoService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRpository;

        public FonercedoService(IFornecedorRepository fonercedorRpository,
                              INotificador notificador) : base(notificador)
        {
            _fornecedorRpository = fonercedorRpository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {

            await _fornecedorRpository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {

            await _fornecedorRpository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            await _fornecedorRpository.Remover(id);
        }
    }

}

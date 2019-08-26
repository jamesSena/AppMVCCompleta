using DevIO.App.Interfaces;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class FonercedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FonercedorService(IFornecedorRepository fonercedorRpository,
                              INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fonercedorRpository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            await _fornecedorRepository.Remover(id);
        }
    }

}

﻿using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<IEnumerable<Endereco>> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
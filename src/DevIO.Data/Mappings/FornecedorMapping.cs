using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> mapping)
        {
            mapping.ToTable("Fornecedor");

            mapping.HasKey(p => p.ID);

            mapping.Property(p => p.Nome)
                .IsRequired() 
                .HasColumnType("varchar(200)");

            mapping.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //1 : 1 => 1 Fornecedor - 1 Endereco
            mapping.HasOne(f=>f.Endereco)
                .WithOne(e=>e.Fornecedor);

            //1 : N => 1 Fornecedor - N Produtos
            mapping.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorID) ;
        }
    }
}

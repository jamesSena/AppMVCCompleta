using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> mapping)
        {
            mapping.ToTable("Endereco");

            mapping.HasKey(p => p.ID);

            mapping.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            mapping.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            mapping.Property(p => p.Cep)
            .IsRequired()
            .HasColumnType("varchar(8)");

            mapping.Property(p => p.Complemento)
                .IsRequired()
                .HasColumnType("varchar(250)");

            mapping.Property(p => p.Bairro)
            .IsRequired()
            .HasColumnType("varchar(100)");

            mapping.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            mapping.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}

using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> mapping)
        {
            mapping.ToTable("Produtos");//Name table
            mapping.HasKey(p => p.ID); // PK
            mapping.Property(p => p.Nome)
                .IsRequired() //not null
                .HasColumnType("varchar(200)"); //Type;
            mapping.Property(p => p.Descricao)
                .IsRequired() 
                .HasColumnType("varchar(100)"); 
            mapping.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");       

        }
    }
}

using Daniel.AulaEnsino.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.AulaEnsino.Core.Data.EntityConfig
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");

            builder
                 .Property(p => p.Codigo)
                 .HasColumnName("id");

            builder.HasKey(p => p.Codigo);

            builder
                 .Property(p => p.Nome)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder
                 .Property(p => p.Descricao)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");

            builder.Property(p => p.Imagem)
                 .HasColumnType("varchar(100)");

            builder
                 .Property(p => p.Valor)
                 .HasColumnName("valor")
                 .HasColumnType("decimal (10,2)");

            builder
                 .Property(p => p.Status)
                 .IsRequired()
                 .HasColumnName("status");

            builder
                 .Property(c => c.DataCadastro)
                 .IsRequired()
                 .HasColumnName("dt_inclusao");

            builder
                 .Property(e => e.DataAlteracao)
                 .HasColumnName("dt_alteracao");

            builder
                 .Property(e => e.DataExclusao)
                 .HasColumnName("dt_exclusao");

            builder
                 .Property(e => e.CodigoCliente)
                 .HasColumnName("idCliente");

            // 1 : * => Cliente : Produtos
            builder
                 .HasOne(c => c.Cliente)
                 .WithMany(p => p.Produtos)
                 .HasForeignKey(p => p.CodigoCliente);
        }
    }
}

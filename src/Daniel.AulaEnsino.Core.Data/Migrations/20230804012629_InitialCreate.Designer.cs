﻿// <auto-generated />
using System;
using Daniel.AulaEnsino.Core.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Daniel.AulaEnsino.Core.Data.Migrations
{
    [DbContext(typeof(MeuContextoBD))]
    [Migration("20230804012629_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Daniel.AulaEnsino.Core.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_alteracao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_inclusao");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_exclusao");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("documento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tipo_pessoa");

                    b.HasKey("Codigo");

                    b.ToTable("cliente", "dbo");
                });

            modelBuilder.Entity("Daniel.AulaEnsino.Core.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("CodigoCliente")
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoCliente")
                        .IsUnique()
                        .HasFilter("[idCliente] IS NOT NULL");

                    b.ToTable("endereco", (string)null);
                });

            modelBuilder.Entity("Daniel.AulaEnsino.Core.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int?>("CodigoCliente")
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_alteracao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_inclusao");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_exclusao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal (10,2)")
                        .HasColumnName("valor");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoCliente");

                    b.ToTable("produto", (string)null);
                });

            modelBuilder.Entity("Daniel.AulaEnsino.Core.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("Daniel.AulaEnsino.Core.Domain.Entities.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("Daniel.AulaEnsino.Core.Domain.Entities.Endereco", "CodigoCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Daniel.AulaEnsino.Core.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Daniel.AulaEnsino.Core.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Produtos")
                        .HasForeignKey("CodigoCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Daniel.AulaEnsino.Core.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
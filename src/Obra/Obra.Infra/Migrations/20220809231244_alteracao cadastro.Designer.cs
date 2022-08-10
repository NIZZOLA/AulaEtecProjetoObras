﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obra.Infra.Data;

#nullable disable

namespace Obra.Infra.Migrations
{
    [DbContext(typeof(ObraMVCContext))]
    [Migration("20220809231244_alteracao cadastro")]
    partial class alteracaocadastro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Obra.Domain.Models.ClienteFornecedorModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Cliente")
                        .HasColumnType("bit");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Cpf")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<bool>("Fornecedor")
                        .HasColumnType("bit");

                    b.Property<string>("InscricaoEstadual")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OptanteDoSimples")
                        .HasColumnType("bit");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UsuarioIdAlteracao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdExclusao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ClienteFornecedor");
                });

            modelBuilder.Entity("Obra.Domain.Models.ContaModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDaCompra")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDoPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EmpreendimentoId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NumeroDoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TipoDeDespesaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipoDeDespesaReceitaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TipoDePagamentoId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdAlteracao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdExclusao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendimentoId");

                    b.HasIndex("TipoDeDespesaReceitaId");

                    b.HasIndex("TipoDePagamentoId");

                    b.ToTable("ContaModel");
                });

            modelBuilder.Entity("Obra.Domain.Models.EmpreendimentoModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOrcamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaTermino")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<Guid?>("UsuarioIdAlteracao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdExclusao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("EmpreendimentoModel");
                });

            modelBuilder.Entity("Obra.Domain.Models.FotoEmpreendimentoModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EmpreendimentoId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeDoArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioIdAlteracao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdExclusao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmpreendimentoId");

                    b.ToTable("FotoEmpreendimentoModel");
                });

            modelBuilder.Entity("Obra.Domain.Models.TipoDeDespesaReceitaModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Despesa")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Receita")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UsuarioIdAlteracao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdExclusao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TipoDeDespesaReceita");
                });

            modelBuilder.Entity("Obra.Domain.Models.TipoDePagamentoModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UsuarioIdAlteracao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioIdExclusao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TipoDePagamento");
                });

            modelBuilder.Entity("Obra.Domain.Models.ContaModel", b =>
                {
                    b.HasOne("Obra.Domain.Models.EmpreendimentoModel", "Empreendimento")
                        .WithMany()
                        .HasForeignKey("EmpreendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obra.Domain.Models.TipoDeDespesaReceitaModel", "TipoDeDespesaReceita")
                        .WithMany("Contas")
                        .HasForeignKey("TipoDeDespesaReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obra.Domain.Models.TipoDePagamentoModel", "TipoDePagamento")
                        .WithMany("Contas")
                        .HasForeignKey("TipoDePagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empreendimento");

                    b.Navigation("TipoDeDespesaReceita");

                    b.Navigation("TipoDePagamento");
                });

            modelBuilder.Entity("Obra.Domain.Models.EmpreendimentoModel", b =>
                {
                    b.HasOne("Obra.Domain.Models.ClienteFornecedorModel", "Cliente")
                        .WithMany("Empreendimentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Obra.Domain.Models.FotoEmpreendimentoModel", b =>
                {
                    b.HasOne("Obra.Domain.Models.EmpreendimentoModel", "Empreendimento")
                        .WithMany()
                        .HasForeignKey("EmpreendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empreendimento");
                });

            modelBuilder.Entity("Obra.Domain.Models.ClienteFornecedorModel", b =>
                {
                    b.Navigation("Empreendimentos");
                });

            modelBuilder.Entity("Obra.Domain.Models.TipoDeDespesaReceitaModel", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("Obra.Domain.Models.TipoDePagamentoModel", b =>
                {
                    b.Navigation("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}

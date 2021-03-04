﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShopDMZ.Data;

namespace eShopDMZ.Migrations
{
    [DbContext(typeof(eShopContext))]
    partial class eShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TBProdutoTBVendidos", b =>
                {
                    b.Property<int>("TBProdutoIDProduto")
                        .HasColumnType("int");

                    b.Property<int>("TBVendidosIDV")
                        .HasColumnType("int");

                    b.HasKey("TBProdutoIDProduto", "TBVendidosIDV");

                    b.HasIndex("TBVendidosIDV");

                    b.ToTable("TBProdutoTBVendidos");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBCategoria", b =>
                {
                    b.Property<int>("IDCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDCategoria");

                    b.ToTable("TBCategoria");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBCliente", b =>
                {
                    b.Property<int>("IDCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TBVendidosIDV")
                        .HasColumnType("int");

                    b.HasKey("IDCliente");

                    b.HasIndex("TBVendidosIDV");

                    b.ToTable("TBCliente");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBFornecedor", b =>
                {
                    b.Property<int>("IDFornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDFornecedor");

                    b.ToTable("TBFornecedor");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBImagem", b =>
                {
                    b.Property<int>("IDImagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDProduto")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("TBProdutoIDProduto")
                        .HasColumnType("int");

                    b.HasKey("IDImagem");

                    b.HasIndex("TBProdutoIDProduto");

                    b.ToTable("TBImagem");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBProduto", b =>
                {
                    b.Property<int>("IDProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDFornecedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TBCategoriaIDCategoria")
                        .HasColumnType("int");

                    b.Property<int?>("TBFornecedorIDFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("Tamanho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDProduto");

                    b.HasIndex("TBCategoriaIDCategoria");

                    b.HasIndex("TBFornecedorIDFornecedor");

                    b.ToTable("TBProduto");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBVendidos", b =>
                {
                    b.Property<int>("IDV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("IDV");

                    b.ToTable("TBVendidos");
                });

            modelBuilder.Entity("TBProdutoTBVendidos", b =>
                {
                    b.HasOne("eShopDMZ.Models.TBProduto", null)
                        .WithMany()
                        .HasForeignKey("TBProdutoIDProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShopDMZ.Models.TBVendidos", null)
                        .WithMany()
                        .HasForeignKey("TBVendidosIDV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShopDMZ.Models.TBCliente", b =>
                {
                    b.HasOne("eShopDMZ.Models.TBVendidos", "TBVendidos")
                        .WithMany("TBCliente")
                        .HasForeignKey("TBVendidosIDV");

                    b.Navigation("TBVendidos");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBImagem", b =>
                {
                    b.HasOne("eShopDMZ.Models.TBProduto", "TBProduto")
                        .WithMany("TBImagem")
                        .HasForeignKey("TBProdutoIDProduto");

                    b.Navigation("TBProduto");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBProduto", b =>
                {
                    b.HasOne("eShopDMZ.Models.TBCategoria", null)
                        .WithMany("TBProduto")
                        .HasForeignKey("TBCategoriaIDCategoria");

                    b.HasOne("eShopDMZ.Models.TBFornecedor", null)
                        .WithMany("TBProduto")
                        .HasForeignKey("TBFornecedorIDFornecedor");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBCategoria", b =>
                {
                    b.Navigation("TBProduto");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBFornecedor", b =>
                {
                    b.Navigation("TBProduto");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBProduto", b =>
                {
                    b.Navigation("TBImagem");
                });

            modelBuilder.Entity("eShopDMZ.Models.TBVendidos", b =>
                {
                    b.Navigation("TBCliente");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using eCommerce.Models.Autenticacao;
using eCommerce.Models.Table;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eCommerce.Models.DataContext
{
    public partial class eCommerceContext : IdentityDbContext<Usuario, Role, string>
    {
        public eCommerceContext()
        {
        }

        public eCommerceContext(DbContextOptions<eCommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Fornecedor> Fornecedors { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }
        public virtual DbSet<Movimento> Movimentos { get; set; }
        public virtual DbSet<MovimentoItem> MovimentoItems { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public virtual DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutoLoja> ProdutoLojas { get; set; }
        public virtual DbSet<TabelaDescritiva> TabelaDescritivas { get; set; }
        public virtual DbSet<TabelaDescritivaConteudo> TabelaDescritivaConteudos { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<TipoMovimento> TipoMovimentos { get; set; }
        public virtual DbSet<Uf> Ufs { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //         {
        //             if (!optionsBuilder.IsConfigured)
        //             {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                 optionsBuilder.UseSqlServer("Server=.;Database=eCommerce;Trusted_Connection=false;User id=eCommerceWeb;Password=123456;");
        //             }
        //         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_100_CI_AI");

            // modelBuilder.Entity<Usuario>(entity =>
            // {
            //     entity.HasNoKey();
            // });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade)
                    .HasName("PK__Cidade__160879A35C50D101");

                entity.ToTable("Cidade");

                entity.Property(e => e.IdUf).HasColumnName("IdUF");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUfNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.IdUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UF_Cidade");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Cliente__7061465D4B0B807C");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdPessoa).ValueGeneratedNever();

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Cliente");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__0B7C7F17261E23E7");

                entity.ToTable("Endereco");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.IdTipo).HasComment("Residencial ou Comercial");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Cidade_Endereco");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Endereco");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoEndereco_Endereco");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Forneced__7061465DE71F5FAE");

                entity.ToTable("Fornecedor");

                entity.Property(e => e.IdPessoa).ValueGeneratedNever();

                entity.Property(e => e.PrazoPrevistoEntrega).HasComment("Prazo médio de entrega pelo fornecedor em dias\r\nCalculado a partir das compras feitas");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithOne(p => p.Fornecedor)
                    .HasForeignKey<Fornecedor>(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Fornecedor");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Funciona__7061465DE535F0CB");

                entity.ToTable("Funcionario");

                entity.Property(e => e.IdPessoa).ValueGeneratedNever();

                entity.Property(e => e.CarteiraTrabalho)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithOne(p => p.Funcionario)
                    .HasForeignKey<Funcionario>(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Funcionario");
            });

            modelBuilder.Entity<Loja>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Loja__7061465DA3E63FAE");

                entity.ToTable("Loja");

                entity.Property(e => e.IdPessoa).ValueGeneratedNever();

                entity.Property(e => e.IdTipoLoja).HasComment("Matriz ou Filial");

                entity.HasOne(d => d.IdLojaMatrizNavigation)
                    .WithMany(p => p.InverseIdLojaMatrizNavigation)
                    .HasForeignKey(d => d.IdLojaMatriz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matriz_Filial");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithOne(p => p.Loja)
                    .HasForeignKey<Loja>(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Loja");

                entity.HasOne(d => d.IdTipoLojaNavigation)
                    .WithMany(p => p.Lojas)
                    .HasForeignKey(d => d.IdTipoLoja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoLoja_Loja");
            });

            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.HasKey(e => e.IdMovimento)
                    .HasName("PK__Moviment__9EBD6E4D04E8E227");

                entity.ToTable("Movimento");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Movimentos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Movimento");

                entity.HasOne(d => d.IdTipoMovimentoNavigation)
                    .WithMany(p => p.Movimentos)
                    .HasForeignKey(d => d.IdTipoMovimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoMovimento_Movimento");
            });

            modelBuilder.Entity<MovimentoItem>(entity =>
            {
                entity.HasKey(e => new { e.IdMovimento, e.IdProdutoLoja })
                    .HasName("PK__Moviment__7B6685F2850D5DC6");

                entity.ToTable("MovimentoItem");

                entity.Property(e => e.Quantidade).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ValorUnitario).HasColumnType("money");

                entity.HasOne(d => d.IdMovimentoNavigation)
                    .WithMany(p => p.MovimentoItems)
                    .HasForeignKey(d => d.IdMovimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimento_MovimentoItem");

                entity.HasOne(d => d.IdProdutoLojaNavigation)
                    .WithMany(p => p.MovimentoItems)
                    .HasForeignKey(d => d.IdProdutoLoja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutoLoja_MovimentoItem");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Pessoa__7061465D49C7CF21");

                entity.ToTable("Pessoa");

                entity.HasIndex(e => e.CpfCnpj, "UQ__Pessoa__0BCA032AA427C2C3")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__PessoaFi__7061465D0AA9C6A4");

                entity.ToTable("PessoaFisica");

                entity.Property(e => e.IdPessoa).ValueGeneratedNever();

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithOne(p => p.PessoaFisica)
                    .HasForeignKey<PessoaFisica>(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_PessoaFisica");
            });

            modelBuilder.Entity<PessoaJuridica>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__PessoaJu__7061465D232A187D");

                entity.ToTable("PessoaJuridica");

                entity.Property(e => e.IdPessoa).ValueGeneratedNever();

                entity.Property(e => e.InscricaoEstadual)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithOne(p => p.PessoaJuridica)
                    .HasForeignKey<PessoaJuridica>(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_PessoaJuridica");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__2E883C23C0F19D0D");

                entity.ToTable("Produto");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValorUnitario).HasColumnType("money");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.ProdutoIdCategoriaNavigations)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categoria_Produto");

                entity.HasOne(d => d.IdCorNavigation)
                    .WithMany(p => p.ProdutoIdCorNavigations)
                    .HasForeignKey(d => d.IdCor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cor_Produto");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.ProdutoIdMarcaNavigations)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marca_Produto");

                entity.HasOne(d => d.IdTamanhoNavigation)
                    .WithMany(p => p.ProdutoIdTamanhoNavigations)
                    .HasForeignKey(d => d.IdTamanho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tamanho_Produto");

                entity.HasOne(d => d.IdUnidadeNavigation)
                    .WithMany(p => p.ProdutoIdUnidadeNavigations)
                    .HasForeignKey(d => d.IdUnidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidade_Produto");
            });

            modelBuilder.Entity<ProdutoLoja>(entity =>
            {
                entity.HasKey(e => e.IdProdutoLoja)
                    .HasName("PK__ProdutoL__5DBEBBFF7D42DEAD");

                entity.ToTable("ProdutoLoja");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.ProdutoLojas)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loja_Produto");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoLojas)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Loja");
            });

            modelBuilder.Entity<TabelaDescritiva>(entity =>
            {
                entity.HasKey(e => e.IdTabelaDescritiva)
                    .HasName("PK__TabelaDe__5C5135773EEC0060");

                entity.ToTable("TabelaDescritiva");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabelaDescritivaConteudo>(entity =>
            {
                entity.HasKey(e => e.IdTabelaDescritivaConteudo)
                    .HasName("PK__TabelaDe__839A5D7F263BD181");

                entity.ToTable("TabelaDescritivaConteudo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTabelaDescritivaNavigation)
                    .WithMany(p => p.TabelaDescritivaConteudos)
                    .HasForeignKey(d => d.IdTabelaDescritiva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TabelaDescritiva_TabelaDescritivaConteudo");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.IdTelefone)
                    .HasName("PK__Telefone__9B8AC7A915EE557C");

                entity.ToTable("Telefone");

                entity.Property(e => e.IdTipo).HasComment("Comercial\r\nResidencial\r\nPessoal");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Telefone");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTelefone206041");
            });

            modelBuilder.Entity<TipoMovimento>(entity =>
            {
                entity.HasKey(e => e.IdTipoMovimento)
                    .HasName("PK__TipoMovi__A9321B46715BAB59");

                entity.ToTable("TipoMovimento");

                entity.Property(e => e.Cliente).HasComment("Busca dados de clientes ao realizar a operação, caso seja verdadeiro (1).\r\nCaso contrário (0), busca dados de fornecedores");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Compra, venda, orçamento");

                entity.Property(e => e.OperacaoEstoque).HasComment("-1: diminuir estoque (movimento de Venda para cliente)\r\n0: não afetar estoque (orçamento)\r\n1: aumenta estoque (movimento de Compra - fornecedor)");
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.HasKey(e => e.IdUf)
                    .HasName("PK__UF__B770025B9D18DDA3");

                entity.ToTable("UF");

                entity.Property(e => e.IdUf).HasColumnName("IdUF");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

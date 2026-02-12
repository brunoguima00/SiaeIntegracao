using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.src.Domain.Entities;

namespace SiaeIntegracao.src.Infrastructure.Data.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CgFilial> CgFilials { get; set; }

    public virtual DbSet<Permisso> Permissoes { get; set; }

    public virtual DbSet<PfCapaPcOnline> PfCapaPcOnlines { get; set; }

    public virtual DbSet<PfDocumento> PfDocumentos { get; set; }

    public virtual DbSet<PfTipoDoc> PfTipoDocs { get; set; }

    public virtual DbSet<PfTipoLancto> PfTipoLanctos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:db-avg.database.windows.net,1433;Initial Catalog=DB_AVG_DEV;Persist Security Info=False;User ID=bruno.guimaraes;Password=Bru10?no?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CgFilial>(entity =>
        {
            entity.HasKey(e => e.IdeProjeto).HasName("Cg_Filial_pkey");

            entity.ToTable("Cg_Filial");

            entity.Property(e => e.IdeProjeto)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ide_Projeto");
            entity.Property(e => e.Acessos)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Ativa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Bairro)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CaracteristicasFisica)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Caracteristicas_Fisica");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cidade)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Complemento)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ContaContabilDebito).HasColumnName("Conta_Contabil_Debito");
            entity.Property(e => e.ContaCredito).HasColumnName("Conta_Credito");
            entity.Property(e => e.ContaGerencial)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Conta_Gerencial");
            entity.Property(e => e.Contabiliza)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DataDaAbertura)
                .HasMaxLength(1000)
                .HasColumnName("Data_da_Abertura");
            entity.Property(e => e.DataDoEncerramento)
                .HasMaxLength(1000)
                .HasColumnName("Data_do_Encerramento");
            entity.Property(e => e.DestinoPatioXml)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Destino_Patio_XML");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.EstabelecimentosConveniados)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Estabelecimentos_Conveniados");
            entity.Property(e => e.HorarioDeFuncionamento)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Horario_de_Funcionamento");
            entity.Property(e => e.IdEmpresa)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Id_Empresa");
            entity.Property(e => e.IdFilial)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Id_Filial");
            entity.Property(e => e.ImportaPatio)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Importa_Patio");
            entity.Property(e => e.InscricaoMunicipal)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Inscricao_Municipal");
            entity.Property(e => e.LanctoBcoPc).HasColumnName("Lancto_Bco_PC");
            entity.Property(e => e.LanctoCatPc).HasColumnName("Lancto_Cat_PC");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Operador)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrdemBcoPc).HasColumnName("Ordem_Bco_PC");
            entity.Property(e => e.OrdemCartPc).HasColumnName("Ordem_Cart_PC");
            entity.Property(e => e.OrigemPatioXml)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Origem_Patio_XML");
            entity.Property(e => e.PontosDeReferencia)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Pontos_de_Referencia");
            entity.Property(e => e.QdeMensalUtilizada).HasColumnName("Qde_Mensal_Utilizada");
            entity.Property(e => e.QdeMensalVenda).HasColumnName("Qde_Mensal_Venda");
            entity.Property(e => e.QdeVagas).HasColumnName("Qde_Vagas");
            entity.Property(e => e.RateiaAprendiz)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Rateia_Aprendiz");
            entity.Property(e => e.RazaoFilial)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Razao_Filial");
            entity.Property(e => e.RazaoReduzidaFilial)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Razao_Reduzida_Filial");
            entity.Property(e => e.Regiao)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegiaoDeInfluencia)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Regiao_de_Influencia");
            entity.Property(e => e.ServicosAdicionais)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Servicos_Adicionais");
            entity.Property(e => e.SistemaAutomacao)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Sistema_Automacao");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoAutomacao)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Tipo_Automacao");
            entity.Property(e => e.TipoDeLocal)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Tipo_de_Local");
            entity.Property(e => e.TipoDeServico)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Tipo_de_Servico");
            entity.Property(e => e.TiposDeUsuario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Tipos_de_Usuario");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UF");
            entity.Property(e => e.UtilizaSite)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("utilizaSite");
            entity.Property(e => e.VisualizaBoleto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Visualiza_Boleto");
            entity.Property(e => e.VisualizaNotaFiscal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Visualiza_Nota_Fiscal");
        });

        modelBuilder.Entity<Permisso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PERMISSO__3213E83F8EB6D95E");

            entity.ToTable("PERMISSOES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Projeto)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("projeto");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Permissos)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__PERMISSOE__email__3A379A64");
        });

        modelBuilder.Entity<PfCapaPcOnline>(entity =>
        {
            entity.HasKey(e => e.IdLancamento).HasName("PK__PF_CAPA___63741DC339F97CBA");

            entity.ToTable("PF_CAPA_PC_ONLINE");

            entity.Property(e => e.IdLancamento).HasColumnName("id_lancamento");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("data_criacao");
            entity.Property(e => e.DataPc).HasColumnName("data_pc");
            entity.Property(e => e.IdeClasse).HasColumnName("ide_classe");
            entity.Property(e => e.IdeDocumento).HasColumnName("ide_documento");
            entity.Property(e => e.IdeEmpresa)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ide_empresa");
            entity.Property(e => e.IdeFilial)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ide_filial");
            entity.Property(e => e.IdeLancamento).HasColumnName("ide_lancamento");
            entity.Property(e => e.IdePojeto)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ide_pojeto");
            entity.Property(e => e.Importado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("importado");
            entity.Property(e => e.Modalidade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("modalidade");
            entity.Property(e => e.OrdemLancamento).HasColumnName("ordem_lancamento");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UsuarioCriou)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario_criou");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<PfDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PF_DOCUM__3213E83F721F12E6");

            entity.ToTable("PF_DOCUMENTOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodDocumento).HasColumnName("cod_documento");
            entity.Property(e => e.DataPc).HasColumnName("data_pc");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.CodDocumentoNavigation).WithMany(p => p.PfDocumentos)
                .HasForeignKey(d => d.CodDocumento)
                .HasConstraintName("FK__PF_DOCUME__cod_d__3572E547");
        });

        modelBuilder.Entity<PfTipoDoc>(entity =>
        {
            entity.HasKey(e => e.CodDocumento).HasName("PK__PF_TIPO___161DAB3C361CDE57");

            entity.ToTable("PF_TIPO_DOCS");

            entity.Property(e => e.CodDocumento)
                .ValueGeneratedNever()
                .HasColumnName("cod_documento");
            entity.Property(e => e.Contabiliza)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contabiliza");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.NomeDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome_documento");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_documento");
        });

        modelBuilder.Entity<PfTipoLancto>(entity =>
        {
            entity.HasKey(e => e.IdeLancamento)
                .HasName("Idx_Seq_Lancamento")
                .IsClustered(false);

            entity.ToTable("PF_TIPO_LANCTOS");

            entity.Property(e => e.IdeLancamento)
                .ValueGeneratedNever()
                .HasColumnName("Ide_Lancamento");
            entity.Property(e => e.Ativo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ClasseFinanceira)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Classe_Financeira");
            entity.Property(e => e.CodigoDocumento).HasColumnName("Codigo_Documento");
            entity.Property(e => e.ContaCredito).HasColumnName("Conta_Credito");
            entity.Property(e => e.ContaDebito).HasColumnName("Conta_Debito");
            entity.Property(e => e.Contabiliza)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DescricaoLancamento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Descricao_Lancamento");
            entity.Property(e => e.GeraDoctoAutomatico)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Gera_Docto_Automatico");
            entity.Property(e => e.IdeEmpresa)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ide_Empresa");
            entity.Property(e => e.IdeFilial)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ide_Filial");
            entity.Property(e => e.IdeOdemPosicionamento).HasColumnName("Ide_Odem_Posicionamento");
            entity.Property(e => e.IdeProjeto)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ide_Projeto");
            entity.Property(e => e.LancamentoTributavel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Lancamento_Tributavel");
            entity.Property(e => e.ModalidadeLancamento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Modalidade_Lancamento");
            entity.Property(e => e.NaturezaDocto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Natureza_Docto");
            entity.Property(e => e.NaturezaMovto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Natureza_Movto");
            entity.Property(e => e.PercentualReceita).HasColumnName("Percentual_Receita");
            entity.Property(e => e.RateiaDebito)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Rateia_Debito");
            entity.Property(e => e.RateioCredito)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Rateio_Credito");
            entity.Property(e => e.TipoDocto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Tipo_Docto");
            entity.Property(e => e.TipoMovto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Tipo_Movto");
            entity.Property(e => e.UtilizaQuantidade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Utiliza_Quantidade");
            entity.Property(e => e.UtilizaValor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Utiliza_Valor");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__USUARIOS__AB6E6165A4DC12D2");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Sobrenome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sobrenome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

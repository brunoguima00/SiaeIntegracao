using System;
using System.Collections.Generic;

namespace SiaeIntegracao.src.Domain.Entities;

public partial class CgFilial
{
    public string IdeProjeto { get; set; } = null!;

    public string IdEmpresa { get; set; } = null!;

    public string IdFilial { get; set; } = null!;

    public string? RazaoFilial { get; set; }

    public string? RazaoReduzidaFilial { get; set; }

    public string? Cnpj { get; set; }

    public string? InscricaoMunicipal { get; set; }

    public string? Logradouro { get; set; }

    public string? Endereco { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Cep { get; set; }

    public string? Regiao { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Operador { get; set; }

    public string? Ativa { get; set; }

    public string? DataDoEncerramento { get; set; }

    public string? SistemaAutomacao { get; set; }

    public string? TipoAutomacao { get; set; }

    public string? VisualizaBoleto { get; set; }

    public string? VisualizaNotaFiscal { get; set; }

    public int? LanctoBcoPc { get; set; }

    public int? OrdemBcoPc { get; set; }

    public int? LanctoCatPc { get; set; }

    public int? OrdemCartPc { get; set; }

    public double? ContaContabilDebito { get; set; }

    public double? ContaCredito { get; set; }

    public string? ContaGerencial { get; set; }

    public string? Contabiliza { get; set; }

    public int? QdeVagas { get; set; }

    public int? QdeMensalUtilizada { get; set; }

    public string? HorarioDeFuncionamento { get; set; }

    public string? TipoDeServico { get; set; }

    public string? CaracteristicasFisica { get; set; }

    public string? Acessos { get; set; }

    public string? ServicosAdicionais { get; set; }

    public string? EstabelecimentosConveniados { get; set; }

    public string? RegiaoDeInfluencia { get; set; }

    public string? PontosDeReferencia { get; set; }

    public string? TiposDeUsuario { get; set; }

    public string? ImportaPatio { get; set; }

    public string? OrigemPatioXml { get; set; }

    public string? DestinoPatioXml { get; set; }

    public string? RateiaAprendiz { get; set; }

    public int? QdeMensalVenda { get; set; }

    public string? TipoDeLocal { get; set; }

    public string? Uf { get; set; }

    public string? DataDaAbertura { get; set; }

    public string? UtilizaSite { get; set; }
}

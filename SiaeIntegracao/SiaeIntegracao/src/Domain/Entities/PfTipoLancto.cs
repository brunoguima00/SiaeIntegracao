using System;
using System.Collections.Generic;

namespace SiaeIntegracao.src.Domain.Entities;

public partial class PfTipoLancto
{
    public long IdeLancamento { get; set; }

    public short IdeOdemPosicionamento { get; set; }

    public string DescricaoLancamento { get; set; } = null!;

    public string ModalidadeLancamento { get; set; } = null!;

    public string UtilizaQuantidade { get; set; } = null!;

    public string UtilizaValor { get; set; } = null!;

    public string GeraDoctoAutomatico { get; set; } = null!;

    public short CodigoDocumento { get; set; }

    public double PercentualReceita { get; set; }

    public string IdeEmpresa { get; set; } = null!;

    public string IdeFilial { get; set; } = null!;

    public string IdeProjeto { get; set; } = null!;

    public string Ativo { get; set; } = null!;

    public string TipoDocto { get; set; } = null!;

    public string NaturezaDocto { get; set; } = null!;

    public string TipoMovto { get; set; } = null!;

    public string NaturezaMovto { get; set; } = null!;

    public string ClasseFinanceira { get; set; } = null!;

    public string Contabiliza { get; set; } = null!;

    public double ContaDebito { get; set; }

    public string RateiaDebito { get; set; } = null!;

    public double ContaCredito { get; set; }

    public string RateioCredito { get; set; } = null!;

    public string LancamentoTributavel { get; set; } = null!;
}

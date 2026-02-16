using System;
using System.Collections.Generic;

namespace SiaeIntegracao.src.Domain.Entities;

public partial class PfDocumento
{
    public long Id { get; set; }

    public DateOnly? DataPc { get; set; }

    public int? CodDocumento { get; set; }

    public decimal? Valor { get; set; }

    public string? Status { get; set; }

    //public virtual PfTipoDoc? CodDocumentoNavigation { get; set; }

    public string Projeto { get; set; } = string.Empty;

    public DateOnly? DataDeposito { get; set; }
    public string? CodAgente { get; set; } = string.Empty;
    public int? IdTipoDoc { get; set; }
}

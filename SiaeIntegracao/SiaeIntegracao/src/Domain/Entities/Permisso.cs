using System;
using System.Collections.Generic;

namespace SiaeIntegracao.src.Domain.Entities;

public partial class Permisso
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Projeto { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? EmailNavigation { get; set; }
}

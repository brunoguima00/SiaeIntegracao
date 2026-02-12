using System;
using System.Collections.Generic;

namespace SiaeIntegracao.src.Domain.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Sobrenome { get; set; }

    public string Email { get; set; } = null!;

    public string? Senha { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Permisso> Permissos { get; set; } = new List<Permisso>();
}

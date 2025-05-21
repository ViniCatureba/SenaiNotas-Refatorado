using System;
using System.Collections.Generic;

namespace SenaiNotas.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? UrlFoto { get; set; }

    public bool Tema { get; set; }

    public bool Fonte { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}

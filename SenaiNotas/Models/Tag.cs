using System;
using System.Collections.Generic;

namespace SenaiNotas.Models;

public partial class Tag
{
    public int IdTag { get; set; }

    public string Nome { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<NotaTag> NotaTags { get; set; } = new List<NotaTag>();
}

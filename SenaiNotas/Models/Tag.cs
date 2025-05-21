using System;
using System.Collections.Generic;

namespace SenaiNotas.Models;

public partial class Tag
{
    public int IdTag { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<NotaTag> NotaTags { get; set; } = new List<NotaTag>();
}

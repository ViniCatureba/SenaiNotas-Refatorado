using System;
using System.Collections.Generic;

namespace SenaiNotas.Models;

public partial class NotaTag
{
    public int IdNotaTag { get; set; }

    public int? IdNota { get; set; }

    public int? IdTag { get; set; }

    public virtual Nota? IdNotaNavigation { get; set; }

    public virtual Tag? IdTagNavigation { get; set; }
}

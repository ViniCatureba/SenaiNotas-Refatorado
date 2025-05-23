using System;
using System.Collections.Generic;

namespace SenaiNotas.Models;

public partial class Nota
{
    public int IdNota { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdAnexo { get; set; }

    public string? Titulo { get; set; }

    public string? Conteudo { get; set; }

    public DateTime? UltimoRefresh { get; set; }

    public DateTime? DataCriacao { get; set; }

    public bool? Arquivado { get; set; }

    public bool Status { get; set; }

    public virtual Anexo? IdAnexoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<NotaTag> NotaTags { get; set; } = new List<NotaTag>();

    public List<string>
}

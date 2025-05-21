using System;
using System.Collections.Generic;

namespace SenaiNotas.Models;

public partial class Anexo
{
    public int IdAnexo { get; set; }

    public string NomeArquivo { get; set; } = null!;

    public DateTime DataUpload { get; set; }

    public string Url { get; set; } = null!;

    public byte[] Arquivo { get; set; } = null!;

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}

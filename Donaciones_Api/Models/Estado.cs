using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }
    [JsonIgnore]
    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();
}

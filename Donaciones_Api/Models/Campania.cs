using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class Campania
{
    public int CampaniaId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public decimal MetaRecaudacion { get; set; }

    public decimal? MontoRecaudado { get; set; }

    public int UsuarioIdcreador { get; set; }

    public bool? Activa { get; set; }

    public DateTime? FechaCreacion { get; set; }
    [JsonIgnore]
    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();
    [JsonIgnore]
    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();
    [JsonIgnore]
    public virtual Usuario? UsuarioIdcreadorNavigation { get; set; } = null;
}

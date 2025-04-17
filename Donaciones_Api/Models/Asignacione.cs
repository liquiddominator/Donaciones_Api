using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class Asignacione
{
    public int AsignacionId { get; set; }

    public int CampaniaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public int UsuarioId { get; set; }

    public string? Comprobante { get; set; }
    [JsonIgnore]
    public virtual Campania? Campania { get; set; } = null;
    [JsonIgnore]
    public virtual ICollection<DetallesAsignacion> DetallesAsignacions { get; set; } = new List<DetallesAsignacion>();
    [JsonIgnore]
    public virtual ICollection<DonacionesAsignacione> DonacionesAsignaciones { get; set; } = new List<DonacionesAsignacione>();
    [JsonIgnore]
    public virtual Usuario? Usuario { get; set; } = null;
}

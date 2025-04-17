using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class DonacionesAsignacione
{
    public int DonacionAsignacionId { get; set; }

    public int DonacionId { get; set; }

    public int AsignacionId { get; set; }

    public decimal MontoAsignado { get; set; }

    public DateTime? FechaAsignacion { get; set; }
    [JsonIgnore]
    public virtual Asignacione? Asignacion { get; set; } = null;
    [JsonIgnore]
    public virtual Donacione? Donacion { get; set; } = null;
}

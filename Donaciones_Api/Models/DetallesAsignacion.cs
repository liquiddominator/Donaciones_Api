using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class DetallesAsignacion
{
    public int DetalleId { get; set; }

    public int AsignacionId { get; set; }

    public string Concepto { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }
    [JsonIgnore]
    public virtual Asignacione? Asignacion { get; set; } = null;
}

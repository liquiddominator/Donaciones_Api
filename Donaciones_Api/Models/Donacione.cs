using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class Donacione
{
    public int DonacionId { get; set; }

    public int? UsuarioId { get; set; }

    public int CampaniaId { get; set; }

    public decimal Monto { get; set; }

    public string TipoDonacion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaDonacion { get; set; }

    public int EstadoId { get; set; }

    public bool? EsAnonima { get; set; }
    [JsonIgnore]
    public virtual Campania? Campania { get; set; } = null;
    [JsonIgnore]
    public virtual ICollection<DonacionesAsignacione> DonacionesAsignaciones { get; set; } = new List<DonacionesAsignacione>();
    [JsonIgnore]
    public virtual Estado? Estado { get; set; } = null;
    [JsonIgnore]
    public virtual SaldosDonacione? SaldosDonacione { get; set; } = null;
    [JsonIgnore]
    public virtual Usuario? Usuario { get; set; } = null;
}

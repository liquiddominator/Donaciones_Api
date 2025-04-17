using System;
using System.Collections.Generic;

namespace Donaciones_Api.Models;

public partial class SaldosDonacione
{
    public int SaldoId { get; set; }

    public int DonacionId { get; set; }

    public decimal MontoOriginal { get; set; }

    public decimal? MontoUtilizado { get; set; }

    public decimal SaldoDisponible { get; set; }

    public DateTime? UltimaActualizacion { get; set; }

    public virtual Donacione? Donacion { get; set; } = null;
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class UsuariosRole
{
    public int UsuarioRolId { get; set; }

    public int UsuarioId { get; set; }

    public int RolId { get; set; }

    public DateTime? FechaAsignacion { get; set; }
    [JsonIgnore]
    public virtual Role? Rol { get; set; } = null;
    [JsonIgnore]
    public virtual Usuario? Usuario { get; set; } = null;
}

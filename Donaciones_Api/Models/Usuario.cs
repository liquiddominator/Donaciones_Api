using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }
    [JsonIgnore]
    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();
    [JsonIgnore]
    public virtual ICollection<Campania> Campania { get; set; } = new List<Campania>();
    [JsonIgnore]
    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();
    [JsonIgnore]
    public virtual ICollection<Mensaje> MensajeUsuarioDestinoNavigations { get; set; } = new List<Mensaje>();
    [JsonIgnore]
    public virtual ICollection<Mensaje> MensajeUsuarioOrigenNavigations { get; set; } = new List<Mensaje>();
    [JsonIgnore]
    public virtual ICollection<RespuestasMensaje> RespuestasMensajes { get; set; } = new List<RespuestasMensaje>();
    [JsonIgnore]
    public virtual ICollection<UsuariosRole> UsuariosRoles { get; set; } = new List<UsuariosRole>();
}

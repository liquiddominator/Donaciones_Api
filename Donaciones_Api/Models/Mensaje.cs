using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class Mensaje
{
    public int MensajeId { get; set; }

    public int UsuarioOrigen { get; set; }

    public int? UsuarioDestino { get; set; }

    public string Asunto { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }

    public bool? Leido { get; set; }

    public bool? Respondido { get; set; }
    [JsonIgnore]
    public virtual ICollection<RespuestasMensaje> RespuestasMensajes { get; set; } = new List<RespuestasMensaje>();
    [JsonIgnore]
    public virtual Usuario? UsuarioDestinoNavigation { get; set; } = null;
    [JsonIgnore]
    public virtual Usuario? UsuarioOrigenNavigation { get; set; } = null;
}

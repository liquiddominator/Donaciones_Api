using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Donaciones_Api.Models;

public partial class RespuestasMensaje
{
    public int RespuestaId { get; set; }

    public int MensajeId { get; set; }

    public int UsuarioId { get; set; }

    public string Contenido { get; set; } = null!;

    public DateTime? FechaRespuesta { get; set; }
    [JsonIgnore]
    public virtual Mensaje? Mensaje { get; set; } = null;
    [JsonIgnore]
    public virtual Usuario? Usuario { get; set; } = null;
}

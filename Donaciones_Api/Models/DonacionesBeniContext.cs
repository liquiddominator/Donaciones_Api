using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Donaciones_Api.Models;

public partial class DonacionesBeniContext : DbContext
{
    public DonacionesBeniContext()
    {
    }

    public DonacionesBeniContext(DbContextOptions<DonacionesBeniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacione> Asignaciones { get; set; }

    public virtual DbSet<Campania> Campanias { get; set; }

    public virtual DbSet<DetallesAsignacion> DetallesAsignacions { get; set; }

    public virtual DbSet<Donacione> Donaciones { get; set; }

    public virtual DbSet<DonacionesAsignacione> DonacionesAsignaciones { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<RespuestasMensaje> RespuestasMensajes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SaldosDonacione> SaldosDonaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosRole> UsuariosRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LIQUIDDOMINATOR\\LIQUIDDOMINATOR;Database=DonacionesBeni;Trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacione>(entity =>
        {
            entity.HasKey(e => e.AsignacionId).HasName("PK__Asignaci__D82B5BB7E2742626");

            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.CampaniaId).HasColumnName("CampaniaID");
            entity.Property(e => e.Comprobante)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Campania).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.CampaniaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asignacio__Campa__5629CD9C");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asignacio__Usuar__571DF1D5");
        });

        modelBuilder.Entity<Campania>(entity =>
        {
            entity.HasKey(e => e.CampaniaId).HasName("PK__Campania__C3E650CC1D0D60FB");

            entity.Property(e => e.CampaniaId).HasColumnName("CampaniaID");
            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetaRecaudacion).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.MontoRecaudado)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioIdcreador).HasColumnName("UsuarioIDCreador");

            entity.HasOne(d => d.UsuarioIdcreadorNavigation).WithMany(p => p.Campania)
                .HasForeignKey(d => d.UsuarioIdcreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Campanias__Usuar__46E78A0C");
        });

        modelBuilder.Entity<DetallesAsignacion>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__Detalles__6E19D6FA2E82FF33");

            entity.ToTable("DetallesAsignacion");

            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.Concepto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Asignacion).WithMany(p => p.DetallesAsignacions)
                .HasForeignKey(d => d.AsignacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesA__Asign__59FA5E80");
        });

        modelBuilder.Entity<Donacione>(entity =>
        {
            entity.HasKey(e => e.DonacionId).HasName("PK__Donacion__9F5DEEE7866601E3");

            entity.Property(e => e.DonacionId).HasColumnName("DonacionID");
            entity.Property(e => e.CampaniaId).HasColumnName("CampaniaID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.EsAnonima).HasDefaultValue(false);
            entity.Property(e => e.EstadoId)
                .HasDefaultValue(1)
                .HasColumnName("EstadoID");
            entity.Property(e => e.FechaDonacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TipoDonacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Campania).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.CampaniaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Donacione__Campa__5165187F");

            entity.HasOne(d => d.Estado).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Donacione__Estad__52593CB8");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Donacione__Usuar__5070F446");
        });

        modelBuilder.Entity<DonacionesAsignacione>(entity =>
        {
            entity.HasKey(e => e.DonacionAsignacionId).HasName("PK__Donacion__41E19328FCDA2AB3");

            entity.Property(e => e.DonacionAsignacionId).HasColumnName("DonacionAsignacionID");
            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.DonacionId).HasColumnName("DonacionID");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoAsignado).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Asignacion).WithMany(p => p.DonacionesAsignaciones)
                .HasForeignKey(d => d.AsignacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Donacione__Asign__6A30C649");

            entity.HasOne(d => d.Donacion).WithMany(p => p.DonacionesAsignaciones)
                .HasForeignKey(d => d.DonacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Donacione__Donac__693CA210");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estados__FEF86B604EBDEACD");

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.MensajeId).HasName("PK__Mensajes__FEA0557F266CB905");

            entity.Property(e => e.MensajeId).HasColumnName("MensajeID");
            entity.Property(e => e.Asunto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contenido).HasColumnType("text");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Leido).HasDefaultValue(false);
            entity.Property(e => e.Respondido).HasDefaultValue(false);

            entity.HasOne(d => d.UsuarioDestinoNavigation).WithMany(p => p.MensajeUsuarioDestinoNavigations)
                .HasForeignKey(d => d.UsuarioDestino)
                .HasConstraintName("FK__Mensajes__Usuari__60A75C0F");

            entity.HasOne(d => d.UsuarioOrigenNavigation).WithMany(p => p.MensajeUsuarioOrigenNavigations)
                .HasForeignKey(d => d.UsuarioOrigen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mensajes__Usuari__5FB337D6");
        });

        modelBuilder.Entity<RespuestasMensaje>(entity =>
        {
            entity.HasKey(e => e.RespuestaId).HasName("PK__Respuest__31F7FC3132B8C8E3");

            entity.Property(e => e.RespuestaId).HasColumnName("RespuestaID");
            entity.Property(e => e.Contenido).HasColumnType("text");
            entity.Property(e => e.FechaRespuesta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MensajeId).HasColumnName("MensajeID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Mensaje).WithMany(p => p.RespuestasMensajes)
                .HasForeignKey(d => d.MensajeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Mensa__6477ECF3");

            entity.HasOne(d => d.Usuario).WithMany(p => p.RespuestasMensajes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Usuar__656C112C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D16F575AB4");

            entity.HasIndex(e => e.Nombre, "UQ__Roles__75E3EFCF353764BD").IsUnique();

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SaldosDonacione>(entity =>
        {
            entity.HasKey(e => e.SaldoId).HasName("PK__SaldosDo__FF916F49EE6F1818");

            entity.HasIndex(e => e.DonacionId, "UQ__SaldosDo__9F5DEEE6B02EE948").IsUnique();

            entity.Property(e => e.SaldoId).HasColumnName("SaldoID");
            entity.Property(e => e.DonacionId).HasColumnName("DonacionID");
            entity.Property(e => e.MontoOriginal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.MontoUtilizado)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)");
            entity.Property(e => e.SaldoDisponible).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UltimaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Donacion).WithOne(p => p.SaldosDonacione)
                .HasForeignKey<SaldosDonacione>(d => d.DonacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaldosDon__Donac__6FE99F9F");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798BE65A41C");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534BDD6BBBA").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuariosRole>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__Usuarios__C869CD2AE73F723D");

            entity.Property(e => e.UsuarioRolId).HasColumnName("UsuarioRolID");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuariosRoles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuariosR__RolID__412EB0B6");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuariosRoles)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuariosR__Usuar__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

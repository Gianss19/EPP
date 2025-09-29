using System;
using System.Collections.Generic;
using EPP_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EPP_Backend.Data;

public partial class EppContext : DbContext
{
    public EppContext()
    {
    }

    public EppContext(DbContextOptions<EppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConceptosEpp> ConceptosEpp { get; set; }

    public virtual DbSet<Direcciones> Direcciones { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<Gerencias> Gerencias { get; set; }

    public virtual DbSet<ItemsSolicitud> ItemsSolicitud { get; set; }

    public virtual DbSet<Puestos> Puestos { get; set; }

    public virtual DbSet<SolicitudEmpleado> SolicitudEmpleado { get; set; }

    public virtual DbSet<Solicitudes> Solicitudes { get; set; }

    public virtual DbSet<Stock> Stock { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ConceptosEpp>(entity =>
        {
            entity.HasKey(e => e.IdEpp).HasName("PRIMARY");

            entity.ToTable("conceptos_epp");

            entity.Property(e => e.IdEpp).HasColumnName("id_epp");
            entity.Property(e => e.Concepto)
                .HasMaxLength(100)
                .HasColumnName("concepto");
            entity.Property(e => e.EsResguardo).HasColumnName("es_resguardo");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasColumnName("unidad_medida");
        });

        modelBuilder.Entity<Direcciones>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PRIMARY");

            entity.ToTable("direcciones");

            entity.Property(e => e.IdDireccion).HasColumnName("id_direccion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.NumEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.IdPuesto, "id_puesto");

            entity.Property(e => e.NumEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("num_empleado");
            entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_ibfk_1");
        });

        modelBuilder.Entity<Gerencias>(entity =>
        {
            entity.HasKey(e => e.IdGerencia).HasName("PRIMARY");

            entity.ToTable("gerencias");

            entity.HasIndex(e => e.IdDireccion, "id_direccion");

            entity.Property(e => e.IdGerencia).HasColumnName("id_gerencia");
            entity.Property(e => e.CentroCostos).HasColumnName("centro_costos");
            entity.Property(e => e.Gerencia)
                .HasMaxLength(100)
                .HasColumnName("gerencia");
            entity.Property(e => e.IdDireccion).HasColumnName("id_direccion");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Gerencias)
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gerencias_ibfk_1");
        });

        modelBuilder.Entity<ItemsSolicitud>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PRIMARY");

            entity.ToTable("items_solicitud");

            entity.HasIndex(e => e.IdEpp, "id_epp");

            entity.HasIndex(e => e.IdSolicitudEmpleado, "id_solicitud_empleado");

            entity.Property(e => e.IdItem).HasColumnName("id_item");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdEpp).HasColumnName("id_epp");
            entity.Property(e => e.IdSolicitudEmpleado).HasColumnName("id_solicitud_empleado");
            entity.Property(e => e.Surtido)
                .HasDefaultValueSql("'0'")
                .HasColumnName("surtido");
            entity.Property(e => e.Talla).HasColumnName("talla");

            entity.HasOne(d => d.IdEppNavigation).WithMany(p => p.ItemsSolicitud)
                .HasForeignKey(d => d.IdEpp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("items_solicitud_ibfk_2");

            entity.HasOne(d => d.IdSolicitudEmpleadoNavigation).WithMany(p => p.ItemsSolicitud)
                .HasForeignKey(d => d.IdSolicitudEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("items_solicitud_ibfk_1");
        });

        modelBuilder.Entity<Puestos>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PRIMARY");

            entity.ToTable("puestos");

            entity.HasIndex(e => e.IdGerencia, "id_gerencia");

            entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");
            entity.Property(e => e.IdGerencia).HasColumnName("id_gerencia");
            entity.Property(e => e.Puesto)
                .HasMaxLength(100)
                .HasColumnName("puesto");

            entity.HasOne(d => d.IdGerenciaNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.IdGerencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("puestos_ibfk_1");
        });

        modelBuilder.Entity<SolicitudEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdSolicitudEmpleado).HasName("PRIMARY");

            entity.ToTable("solicitud_empleado");

            entity.HasIndex(e => e.IdSolicitud, "id_solicitud");

            entity.HasIndex(e => e.NumEmpleado, "num_empleado");

            entity.Property(e => e.IdSolicitudEmpleado).HasColumnName("id_solicitud_empleado");
            entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            entity.Property(e => e.NumEmpleado).HasColumnName("num_empleado");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasColumnName("rol");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.SolicitudEmpleado)
                .HasForeignKey(d => d.IdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitud_empleado_ibfk_1");

            entity.HasOne(d => d.NumEmpleadoNavigation).WithMany(p => p.SolicitudEmpleado)
                .HasForeignKey(d => d.NumEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitud_empleado_ibfk_2");
        });

        modelBuilder.Entity<Solicitudes>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PRIMARY");

            entity.ToTable("solicitudes");

            entity.HasIndex(e => e.IdSolicitante, "id_solicitante");

            entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.IdSolicitante).HasColumnName("id_solicitante");
            entity.Property(e => e.Justificacion)
                .HasMaxLength(200)
                .HasColumnName("justificacion");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.IdSolicitanteNavigation).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.IdSolicitante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitudes_ibfk_1");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.IdEpp).HasName("PRIMARY");

            entity.ToTable("stock");

            entity.Property(e => e.IdEpp)
                .ValueGeneratedNever()
                .HasColumnName("id_epp");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdEppNavigation).WithOne(p => p.Stock)
                .HasForeignKey<Stock>(d => d.IdEpp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stock_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "correo").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IntentosFallidos).HasColumnName("intentos_fallidos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Pass)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("pass");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
            entity.Property(e => e.Salt)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("salt");
            entity.Property(e => e.UltimoCambio)
                .HasColumnType("datetime")
                .HasColumnName("ultimo_cambio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

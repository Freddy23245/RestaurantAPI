using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaRestauranteAPI.Models;

namespace SistemaRestauranteAPI.Data;

public partial class SistemaRestauranteContext : DbContext
{
    public SistemaRestauranteContext()
    {
    }

    public SistemaRestauranteContext(DbContextOptions<SistemaRestauranteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categoria { get; set; }

    public virtual DbSet<EstadoPago> EstadoPagos { get; set; }

    public virtual DbSet<EstadoSesionMesa> EstadoSesionMesas { get; set; }

    public virtual DbSet<MedioPago> MedioPagos { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<PedidoEstado> PedidoEstados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<SesionMesa> SesionMesas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-UV8F7GP; Database=SistemaRestaurante; Trusted_Connection=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.HasIndex(e => e.Nombre, "UQ_Categoria_Nombre").IsUnique();

            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoPago>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPago).HasName("PK__Estado_P__468227A53A117E2D");

            entity.ToTable("Estado_Pago");

            entity.Property(e => e.IdEstadoPago).HasColumnName("IdEstado_Pago");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoSesionMesa>(entity =>
        {
            entity.HasKey(e => e.IdEstadoSesionMesa).HasName("PK__Estado_S__C2ADE2CEEAD6EAFD");

            entity.ToTable("Estado_Sesion_Mesa");

            entity.Property(e => e.IdEstadoSesionMesa).HasColumnName("IdEstado_Sesion_Mesa");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MedioPago>(entity =>
        {
            entity.HasKey(e => e.IdMedioPago).HasName("PK__Medio_Pa__11B4773EE4EC7C10");

            entity.ToTable("Medio_Pago");

            entity.Property(e => e.IdMedioPago).HasColumnName("IdMedio_Pago");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa);

            entity.ToTable("Mesa");

            entity.HasIndex(e => e.CodigoQr, "UQ_Mesa_CodigoQR").IsUnique();

            entity.HasIndex(e => e.Numero, "UQ_Mesa_Numero").IsUnique();

            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.CodigoQr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CodigoQR");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago);

            entity.ToTable("Pago");

            entity.Property(e => e.FechaHora).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IdEstadoPago)
                .HasDefaultValue(1)
                .HasColumnName("IdEstado_Pago");
            entity.Property(e => e.IdMedioPago).HasColumnName("IdMedio_Pago");
            entity.Property(e => e.Importe).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdEstadoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdEstadoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estado_Pago");

            entity.HasOne(d => d.IdMedioPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdMedioPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medio_Pago");

            entity.HasOne(d => d.IdSesionMesaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdSesionMesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_SesionMesa");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.ToTable("Pedido");

            entity.Property(e => e.FechaHora).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IdPedidoEstado)
                .HasDefaultValue(1)
                .HasColumnName("IdPedido_Estado");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdPedidoEstadoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPedidoEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Estado");

            entity.HasOne(d => d.IdSesionMesaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdSesionMesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_SesionMesa");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdPedidoDetalle);

            entity.ToTable("PedidoDetalle");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoDetalle_Pedido");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoDetalle_Producto");
        });

        modelBuilder.Entity<PedidoEstado>(entity =>
        {
            entity.HasKey(e => e.IdPedidoEstado).HasName("PK__Pedido_E__2603C1333EF63AAC");

            entity.ToTable("Pedido_Estado");

            entity.Property(e => e.IdPedidoEstado).HasColumnName("IdPedido_Estado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("Producto");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<SesionMesa>(entity =>
        {
            entity.HasKey(e => e.IdSesionMesa);

            entity.ToTable("SesionMesa");

            entity.Property(e => e.FechaInicio).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IdEstadoSesionMesa)
                .HasDefaultValue(1)
                .HasColumnName("IdEstado_Sesion_Mesa");

            entity.HasOne(d => d.IdEstadoSesionMesaNavigation).WithMany(p => p.SesionMesas)
                .HasForeignKey(d => d.IdEstadoSesionMesa)
                .HasConstraintName("FK_Estado_SesionMesa_Mesa");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.SesionMesas)
                .HasForeignKey(d => d.IdMesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SesionMesa_Mesa");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Usuario1, "UQ_Usuario_Usuario").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

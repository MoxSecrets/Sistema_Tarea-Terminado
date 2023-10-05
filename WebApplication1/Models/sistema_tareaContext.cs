using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class sistema_tareaContext : DbContext
    {
        public sistema_tareaContext()
        {
        }

        public sistema_tareaContext(DbContextOptions<sistema_tareaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FpComentario> FpComentarios { get; set; } = null!;
        public virtual DbSet<FpDetalleProyecto> FpDetalleProyectos { get; set; } = null!;
        public virtual DbSet<FpProyecto> FpProyectos { get; set; } = null!;
        public virtual DbSet<FpTarea> FpTareas { get; set; } = null!;
        public virtual DbSet<FpUsuario> FpUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=sistema_tarea", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<FpComentario>(entity =>
            {
                entity.HasKey(e => e.ComId)
                    .HasName("PRIMARY");

                entity.ToTable("fp_comentario");

                entity.HasIndex(e => e.ComTareaId, "FK_TAR_COM");

                entity.Property(e => e.ComId)
                    .HasColumnType("int(11)")
                    .HasColumnName("com_id");

                entity.Property(e => e.ComContenido)
                    .HasMaxLength(90)
                    .HasColumnName("com_contenido");

                entity.Property(e => e.ComFechaCreacion).HasColumnName("com_fecha_creacion");

                entity.Property(e => e.ComTareaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("com_tarea_id");

                entity.HasOne(d => d.ComTarea)
                    .WithMany(p => p.FpComentarios)
                    .HasForeignKey(d => d.ComTareaId)
                    .HasConstraintName("FK_TAR_COM");
            });

            modelBuilder.Entity<FpDetalleProyecto>(entity =>
            {
                entity.HasKey(e => e.DproId)
                    .HasName("PRIMARY");

                entity.ToTable("fp_detalle_proyecto");

                entity.HasIndex(e => e.DproProyecto, "FK_PRO_DPRO");

                entity.HasIndex(e => e.DproUsuario, "FK_USU_DPRO");

                entity.Property(e => e.DproId)
                    .HasColumnType("int(11)")
                    .HasColumnName("dpro_id");

                entity.Property(e => e.DproFechaIntegracion).HasColumnName("dpro_fecha_integracion");

                entity.Property(e => e.DproProyecto)
                    .HasColumnType("int(11)")
                    .HasColumnName("dpro_proyecto");

                entity.Property(e => e.DproUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("dpro_usuario");

                entity.HasOne(d => d.DproProyectoNavigation)
                    .WithMany(p => p.FpDetalleProyectos)
                    .HasForeignKey(d => d.DproProyecto)
                    .HasConstraintName("FK_PRO_DPRO");

                entity.HasOne(d => d.DproUsuarioNavigation)
                    .WithMany(p => p.FpDetalleProyectos)
                    .HasForeignKey(d => d.DproUsuario)
                    .HasConstraintName("FK_USU_DPRO");
            });

            modelBuilder.Entity<FpProyecto>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PRIMARY");

                entity.ToTable("fp_proyecto");

                entity.HasIndex(e => e.ProTareaId, "FK_TAR_PRO");

                entity.Property(e => e.ProId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pro_id");

                entity.Property(e => e.ProDescripcion)
                    .HasMaxLength(50)
                    .HasColumnName("pro_descripcion");

                entity.Property(e => e.ProFechaFinalizacion).HasColumnName("pro_fecha_finalizacion");

                entity.Property(e => e.ProFechaInicio).HasColumnName("pro_fecha_inicio");

                entity.Property(e => e.ProNombre)
                    .HasMaxLength(20)
                    .HasColumnName("pro_nombre");

                entity.Property(e => e.ProTareaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pro_tarea_id");

                entity.HasOne(d => d.ProTarea)
                    .WithMany(p => p.FpProyectos)
                    .HasForeignKey(d => d.ProTareaId)
                    .HasConstraintName("FK_TAR_PRO");
            });

            modelBuilder.Entity<FpTarea>(entity =>
            {
                entity.HasKey(e => e.TarId)
                    .HasName("PRIMARY");

                entity.ToTable("fp_tarea");

                entity.HasIndex(e => e.TarAsignacion, "FK_USU_TAR");

                entity.Property(e => e.TarId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tar_id");

                entity.Property(e => e.TarAsignacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("tar_asignacion");

                entity.Property(e => e.TarCompletada)
                    .HasMaxLength(10)
                    .HasColumnName("tar_completada");

                entity.Property(e => e.TarDescripcion)
                    .HasMaxLength(50)
                    .HasColumnName("tar_descripcion");

                entity.Property(e => e.TarFechaVencimiento).HasColumnName("tar_fecha_vencimiento");

                entity.Property(e => e.TarNombre)
                    .HasMaxLength(20)
                    .HasColumnName("tar_nombre");

                entity.HasOne(d => d.TarAsignacionNavigation)
                    .WithMany(p => p.FpTareas)
                    .HasForeignKey(d => d.TarAsignacion)
                    .HasConstraintName("FK_USU_TAR");
            });

            modelBuilder.Entity<FpUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuId)
                    .HasName("PRIMARY");

                entity.ToTable("fp_usuario");

                entity.Property(e => e.UsuId)
                    .HasColumnType("int(11)")
                    .HasColumnName("usu_id");

                entity.Property(e => e.UsuContrasena)
                    .HasMaxLength(8)
                    .HasColumnName("usu_contrasena");

                entity.Property(e => e.UsuCorreo)
                    .HasMaxLength(40)
                    .HasColumnName("usu_correo");

                entity.Property(e => e.UsuNombre)
                    .HasMaxLength(15)
                    .HasColumnName("usu_nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

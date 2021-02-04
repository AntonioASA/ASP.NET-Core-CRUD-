using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplicacionCRUD.Models
{
    public partial class TESTContext : DbContext
    {
        public TESTContext()
        {
        }

        public TESTContext(DbContextOptions<TESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<CiudadEstado> CiudadEstado { get; set; }
        public virtual DbSet<Colonia> Colonia { get; set; }
        public virtual DbSet<DelegacionMunicipio> DelegacionMunicipio { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<VwCiudadMunicipio> VwCiudadMunicipio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-8LOJ0QBC; Initial catalog=TEST; user id=sa; password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumno__460B4740758C45A7");

                entity.Property(e => e.ApMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BanActivo).HasColumnName("banActivo");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CiudadEstado>(entity =>
            {
                entity.HasKey(e => e.IdCiudadEstado)
                    .HasName("PK__Ciudad_E__712C33E1F21427BF");

                entity.ToTable("Ciudad_Estado");

                entity.Property(e => e.IdCiudadEstado)
                    .HasColumnName("idCiudadEstado")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Colonia>(entity =>
            {
                entity.HasKey(e => e.IdColonia)
                    .HasName("PK__colonia__DF3A11324BCCBB59");

                entity.ToTable("colonia");

                entity.Property(e => e.IdColonia)
                    .HasColumnName("idColonia")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdDelMun).HasColumnName("idDelMun");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDelMunNavigation)
                    .WithMany(p => p.Colonia)
                    .HasForeignKey(d => d.IdDelMun)
                    .HasConstraintName("FK_idDelMuno");
            });

            modelBuilder.Entity<DelegacionMunicipio>(entity =>
            {
                entity.HasKey(e => e.IdDelMun)
                    .HasName("PK__Delegaci__37A7E75F2AD477EC");

                entity.ToTable("Delegacion_Municipio");

                entity.Property(e => e.IdDelMun)
                    .HasColumnName("idDelMun")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdciudadEstado).HasColumnName("idciudadEstado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdciudadEstadoNavigation)
                    .WithMany(p => p.DelegacionMunicipio)
                    .HasForeignKey(d => d.IdciudadEstado)
                    .HasConstraintName("FK_idCiudadEstado");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.QuotationNo)
                    .HasName("PK__sales__78413F48FC3BFA21");

                entity.ToTable("sales");

                entity.Property(e => e.QuotationNo).HasColumnName("quotation_no");

                entity.Property(e => e.BanActivo).HasColumnName("banActivo");

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("valid_from")
                    .HasColumnType("date");

                entity.Property(e => e.ValidTo)
                    .HasColumnName("valid_to")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A603219C1D");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCiudadMunicipio>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCiudadMunicipio");

                entity.Property(e => e.NombreDeDelegacionMunicipio)
                    .HasColumnName("Nombre de Delegacion / Municipio")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDeLaCiudad)
                    .HasColumnName("Nombre de la Ciudad")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

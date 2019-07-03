using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fixbi.Domains
{
    public partial class FixBiContext : DbContext
    {
        public FixBiContext()
        {
        }

        public FixBiContext(DbContextOptions<FixBiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atendimentos> Atendimentos { get; set; }
        public virtual DbSet<Ciclistas> Ciclistas { get; set; }
        public virtual DbSet<Mecanicos> Mecanicos { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-C2G6OVOK;Initial Catalog=FIXBI;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Atendimentos>(entity =>
            {
                entity.HasKey(e => e.IdAtendimento)
                    .HasName("PK__ATENDIME__B551D4064B230FE7");

                entity.ToTable("ATENDIMENTOS");

                entity.Property(e => e.IdAtendimento).HasColumnName("ID_ATENDIMENTO");

                entity.Property(e => e.DataHorario)
                    .HasColumnName("DATA_HORARIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoAtendimento)
                    .HasColumnName("DESCRICAO_ATENDIMENTO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCiclista).HasColumnName("ID_CICLISTA");

                entity.Property(e => e.IdMecanico).HasColumnName("ID_MECANICO");

                entity.Property(e => e.SituacaoAtendimento)
                    .IsRequired()
                    .HasColumnName("SITUACAO_ATENDIMENTO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiclistaNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdCiclista)
                    .HasConstraintName("FK__ATENDIMEN__ID_CI__47DBAE45");

                entity.HasOne(d => d.IdMecanicoNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdMecanico)
                    .HasConstraintName("FK__ATENDIMEN__ID_ME__48CFD27E");
            });

            modelBuilder.Entity<Ciclistas>(entity =>
            {
                entity.HasKey(e => e.IdCiclista)
                    .HasName("PK__CICLISTA__45A004FC65EBC04C");

                entity.ToTable("CICLISTAS");

                entity.HasIndex(e => e.TelefoneCiclista)
                    .HasName("UQ__CICLISTA__6F3ED153DF3E11C3")
                    .IsUnique();

                entity.Property(e => e.IdCiclista).HasColumnName("ID_CICLISTA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.InformacoesCiclista)
                    .HasColumnName("INFORMACOES_CICLISTA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCiclista)
                    .IsRequired()
                    .HasColumnName("NOME_CICLISTA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneCiclista)
                    .IsRequired()
                    .HasColumnName("TELEFONE_CICLISTA")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ciclistas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CICLISTAS__ID_US__3F466844");
            });

            modelBuilder.Entity<Mecanicos>(entity =>
            {
                entity.HasKey(e => e.IdMecanico)
                    .HasName("PK__MECANICO__450EE18EF5097F5C");

                entity.ToTable("MECANICOS");

                entity.HasIndex(e => e.TelefoneMecanico)
                    .HasName("UQ__MECANICO__2C4A0B4C1B64EE00")
                    .IsUnique();

                entity.Property(e => e.IdMecanico).HasColumnName("ID_MECANICO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.InformacoesMecanico)
                    .HasColumnName("INFORMACOES_MECANICO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMecanico)
                    .IsRequired()
                    .HasColumnName("NOME_MECANICO")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneMecanico)
                    .IsRequired()
                    .HasColumnName("TELEFONE_MECANICO")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Mecanicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__MECANICOS__ID_US__44FF419A");
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPO_USU__85A05968AA750F09");

                entity.ToTable("TIPO_USUARIOS");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("TIPO_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIOS__91136B9018845C1D");

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.EmailUsuario)
                    .HasName("UQ__USUARIOS__A3C14D493DB996BD")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasColumnName("EMAIL_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasColumnName("SENHA_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rand()*(10))");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__3A81B327");
            });
        }
    }
}

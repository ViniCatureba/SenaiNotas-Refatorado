using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SenaiNotas.Models;

namespace SenaiNotas.Context;
//oi
public partial class SenaiNotesContext : DbContext
{
    public SenaiNotesContext()
    {
    }

    public SenaiNotesContext(DbContextOptions<SenaiNotesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anexo> Anexos { get; set; }

    public virtual DbSet<AuditoriaGeral> AuditoriaGerals { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<NotaTag> NotaTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:senainotasalpha.database.windows.net,1433;Initial Catalog=SenaiNotes;Persist Security Info=False;User ID=senai;Password=S3nai@134;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anexo>(entity =>
        {
            entity.HasKey(e => e.IdAnexo).HasName("PK__Anexo__A3A70BAA73CD9A00");

            entity.ToTable("Anexo", tb => tb.HasTrigger("trg_audit_Anexo"));

            entity.Property(e => e.IdAnexo).HasColumnName("idAnexo");
            entity.Property(e => e.DataUpload)
                .HasColumnType("datetime")
                .HasColumnName("dataUpload");
            entity.Property(e => e.NomeArquivo)
                .IsUnicode(false)
                .HasColumnName("nomeArquivo");
            entity.Property(e => e.Url)
                .HasMaxLength(1)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<AuditoriaGeral>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria).HasName("PK__Auditori__7FD13FA0BD233FEE");

            entity.ToTable("AuditoriaGeral");

            entity.Property(e => e.DadosAntigos).IsUnicode(false);
            entity.Property(e => e.DadosNovos).IsUnicode(false);
            entity.Property(e => e.DataAcao).HasColumnType("datetime");
            entity.Property(e => e.NomeTabela)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoAcao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PK__Notas__AD5F462E89F6ABCC");

            entity.ToTable(tb => tb.HasTrigger("trg_audit_Notas"));

            entity.Property(e => e.IdNota).HasColumnName("idNota");
            entity.Property(e => e.DataCriacao)
                .HasColumnType("datetime")
                .HasColumnName("dataCriacao");
            entity.Property(e => e.IdAnexo).HasColumnName("idAnexo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UltimoRefresh)
                .HasColumnType("datetime")
                .HasColumnName("ultimoRefresh");

            entity.HasOne(d => d.IdAnexoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdAnexo)
                .HasConstraintName("FK__Notas__idAnexo__6383C8BA");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Notas__idUsuario__628FA481");
        });

        modelBuilder.Entity<NotaTag>(entity =>
        {
            entity.HasKey(e => e.IdNotaTag).HasName("PK__NotaTag__97932B08094079DF");

            entity.ToTable("NotaTag", tb => tb.HasTrigger("trg_audit_NotaTag"));

            entity.Property(e => e.IdNotaTag).HasColumnName("idNotaTag");
            entity.Property(e => e.IdNota).HasColumnName("idNota");
            entity.Property(e => e.IdTag).HasColumnName("idTag");

            entity.HasOne(d => d.IdNotaNavigation).WithMany(p => p.NotaTags)
                .HasForeignKey(d => d.IdNota)
                .HasConstraintName("FK__NotaTag__idNota__66603565");

            entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.NotaTags)
                .HasForeignKey(d => d.IdTag)
                .HasConstraintName("FK__NotaTag__idTag__6754599E");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.IdTag).HasName("PK__TAG__020FEDB81730BD98");

            entity.ToTable("Tag", tb => tb.HasTrigger("trg_audit_Tag"));

            entity.Property(e => e.IdTag).HasColumnName("idTag");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A656A13B52");

            entity.ToTable(tb => tb.HasTrigger("trg_audit_Usuarios"));

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha).IsUnicode(false);
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(100)
                .HasColumnName("urlFoto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

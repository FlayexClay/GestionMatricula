using System;
using System.Collections.Generic;
using GestionMatricula.Entidades.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestionMatricula.AccesoDatos.Contexto;

public partial class BdGestionContext : DbContext
{
    public BdGestionContext()
    {
    }

    public BdGestionContext(DbContextOptions<BdGestionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumno__3214EC07A435F1A5");

            entity.ToTable("Alumno");

            entity.HasIndex(e => e.Email, "UQ__Alumno__A9D105344AF0E753").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curso__3214EC071376358F");

            entity.ToTable("Curso");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Matricul__3214EC0755EC035F");

            entity.ToTable("Matricula");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaMatricula).HasColumnType("datetime");

            entity.HasOne(d => d.Alumno).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matricula_Alumno");

            entity.HasOne(d => d.Curso).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matricula_Curso");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

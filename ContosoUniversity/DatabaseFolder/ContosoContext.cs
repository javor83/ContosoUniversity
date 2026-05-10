using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.DatabaseFolder;

public partial class ContosoContext : DbContext
{
    public ContosoContext()
    {
    }

    public ContosoContext(DbContextOptions<ContosoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cource> Cources { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COURCES__3214EC27E62C414A");

            entity.ToTable("COURCES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Credits).HasColumnName("CREDITS");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ENROLLME__3214EC273B1F7F38");

            entity.ToTable("ENROLLMENTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Courceid).HasColumnName("COURCEID");
            entity.Property(e => e.Grade).HasColumnName("GRADE");
            entity.Property(e => e.Studentid).HasColumnName("STUDENTID");

            entity.HasOne(d => d.Cource).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.Courceid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ENROLLMEN__COURC__4E88ABD4");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ENROLLMEN__STUDE__4D94879B");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC27AE7E5424");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Enrollmentdate)
                .HasColumnType("datetime")
                .HasColumnName("ENROLLMENTDATE");
            entity.Property(e => e.Fname)
                .HasMaxLength(100)
                .HasColumnName("FNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

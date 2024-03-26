using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SmartSchool.Models;

public partial class SmartSchoolContext : DbContext
{
    public SmartSchoolContext()
    {
    }

    public SmartSchoolContext(DbContextOptions<SmartSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Recognition> Recognitions { get; set; }

    public virtual DbSet<Student> Students { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__Parent__D339516FAEFE067B");

            entity.ToTable("Parent");

            entity.Property(e => e.ParentId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ParentName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Zalo).HasMaxLength(50);
        });

        modelBuilder.Entity<Recognition>(entity =>
        {
            entity.HasKey(e => e.RecognitionId).HasName("PK__Recognit__4E43A924279E199A");

            entity.Property(e => e.RecognitionId).ValueGeneratedNever();
            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Student).WithMany(p => p.Recognitions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Recogniti__Stude__29572725");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B9940E407D9");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasMaxLength(20);
            entity.Property(e => e.StudentName).HasMaxLength(100);

            entity.HasOne(d => d.Parent).WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Student__ParentI__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

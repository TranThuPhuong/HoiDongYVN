using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoiDongYVN.Models
{
    public partial class db_HoiDongYVNContext : DbContext
    {
        public db_HoiDongYVNContext()
        {
        }

        public db_HoiDongYVNContext(DbContextOptions<db_HoiDongYVNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Creator> TblCreators { get; set; }
        public virtual DbSet<Post> TblPosts { get; set; }
        public virtual DbSet<Tag> TblTags { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-171AVQP;Initial Catalog=db_HoiDongYVN;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creator>(entity =>
            {
                entity.HasKey(e => e.PkICreatorId)
                    .HasName("PK_Creator");

                entity.ToTable("tblCreator");

                entity.Property(e => e.PkICreatorId).HasColumnName("PK_iCreatorID");

                entity.Property(e => e.IRole).HasColumnName("iRole");

                entity.Property(e => e.IStatus).HasColumnName("iStatus");

                entity.Property(e => e.SEmail)
                    .HasMaxLength(255)
                    .HasColumnName("sEmail");

                entity.Property(e => e.SFullname)
                    .HasMaxLength(50)
                    .HasColumnName("sFullname");

                entity.Property(e => e.SPassword)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("sPassword");

                entity.Property(e => e.SPhone)
                    .HasMaxLength(10)
                    .HasColumnName("sPhone");

                entity.Property(e => e.SUsername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sUsername");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PkIPostId)
                    .HasName("PK_Post");

                entity.ToTable("tblPost");

                entity.Property(e => e.PkIPostId).HasColumnName("PK_iPostID");

                entity.Property(e => e.DCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dCreatedDate");

                entity.Property(e => e.DUpDatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dUpDatedDate");

                entity.Property(e => e.FkICreatorId).HasColumnName("FK_iCreatorID");

                entity.Property(e => e.FkITagId).HasColumnName("FK_iTagID");

                entity.Property(e => e.IStatus).HasColumnName("iStatus");

                entity.Property(e => e.SContent).HasColumnName("sContent");

                entity.Property(e => e.SDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("sDescription");

                entity.Property(e => e.SImage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("sImage");

                entity.Property(e => e.SSource)
                    .HasMaxLength(150)
                    .HasColumnName("sSource");

                entity.Property(e => e.STitle)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("sTitle");

                entity.HasOne(d => d.FkICreator)
                    .WithMany(p => p.TblPosts)
                    .HasForeignKey(d => d.FkICreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Creator");

                entity.HasOne(d => d.FkITag)
                    .WithMany(p => p.TblPosts)
                    .HasForeignKey(d => d.FkITagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Tag");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.PkITagId)
                    .HasName("PK_Tag");

                entity.ToTable("tblTag");

                entity.Property(e => e.PkITagId).HasColumnName("PK_iTagID");

                entity.Property(e => e.IStatus).HasColumnName("iStatus");

                entity.Property(e => e.STagname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sTagname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

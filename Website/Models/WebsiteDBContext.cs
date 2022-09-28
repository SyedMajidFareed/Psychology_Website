using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Website.Models.Repositories;

namespace Website.Models
{
    public partial class WebsiteDBContext : DbContext
    {
        private readonly UserRepository Iuser= new UserRepository();
        private readonly TherapistRepository Itherapist= new TherapistRepository();
        private readonly AdminRepository Iadmin= new AdminRepository();
        public static int ID = 0;
        public WebsiteDBContext()
        {
        }

        public WebsiteDBContext(DbContextOptions<WebsiteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserTable> UserTables { get; set; } = null!;
        public virtual DbSet<ContentData> ContentItems { get; set; } = null!;
        public virtual DbSet<Therapist> Therapists { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("UserTable");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public override int SaveChanges()
        {
            int idUser = Iuser.getUserID();
            int idTherapist = Itherapist.getTherapistID();
            int idAdmin = Iadmin.getAdminID();
            if(idUser!=0)
            {
                ID = idUser;
            }
            else if (idTherapist != 0)
            {
                ID = idTherapist;
            }
            else if (idAdmin != 0)
            {
                ID = idAdmin;
            }

            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is AuditModel)
                {
                    var referenceEntity = entry.Entity as ContentData;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedDate = DateTime.Now;
                            referenceEntity.CreatedByUserId = ID.ToString();

                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceEntity.LastModifiedDate = DateTime.Now;
                            referenceEntity.LastModifiedUserId = ID.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}

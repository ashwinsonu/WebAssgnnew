using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAssgn.AssignModel
{
    public partial class chaatsContext : DbContext
    {
        public chaatsContext()
        {
        }

        public chaatsContext(DbContextOptions<chaatsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buy> Buys { get; set; }
        public virtual DbSet<Chaat> Chaats { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Logintbl> Logintbls { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:chaatsteam.database.windows.net,1433;Initial Catalog=chaats;Persist Security Info=False; User ID =team8;Password=teameight@8;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"); //Server = KANINI - LTP - 454\\SQLSERVER2019ASH; Database = chaats; Trusted_Connection = True;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Buy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Buy");

                entity.Property(e => e.Addr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardNo).HasMaxLength(50);

                entity.Property(e => e.Doe)
                    .HasColumnType("date")
                    .HasColumnName("DOE");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Number).HasMaxLength(50);
            });

            modelBuilder.Entity<Chaat>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Chaats__C1F8DC39AE4AF237");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CId");

                entity.Property(e => e.Cimage)
                    .HasMaxLength(50)
                    .HasColumnName("CImage");

                entity.Property(e => e.Cname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CName");

                entity.Property(e => e.Cprice).HasColumnName("CPrice");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK__Drinks__C0365650CBF29D80");

                entity.Property(e => e.Did)
                    .ValueGeneratedNever()
                    .HasColumnName("DId");

                entity.Property(e => e.Dimage)
                    .HasMaxLength(50)
                    .HasColumnName("DImage");

                entity.Property(e => e.Dname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DName");
            });

            modelBuilder.Entity<Logintbl>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Logintbl__536C85E5EF902546");

                entity.ToTable("Logintbl");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Item)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Toa)
                    .HasColumnType("datetime")
                    .HasColumnName("TOA");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__UserLogi__536C85E5093856C5");

                entity.ToTable("UserLogin");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

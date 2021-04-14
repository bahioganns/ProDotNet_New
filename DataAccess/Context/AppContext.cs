using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Context
{
    public partial class BooksAppContext : DbContext
    {
        public BooksAppContext()
        {
        }

        public BooksAppContext(DbContextOptions<BooksAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=books.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(book => book.Visitor)
                      .WithMany(visitor => visitor.Books)
                      .HasForeignKey(book => book.VisitorId);

                entity.Property(book => book.Name).IsRequired();
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(visitor => visitor.Login).IsRequired();
                entity.HasIndex(visitor => visitor.Login).IsUnique();
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

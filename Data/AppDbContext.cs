namespace BooksWebApi.Data
{
    using BooksWebApi.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => new { x.AuthorId, x.BookId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(x => x.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(x => x.Author)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(bi => bi.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }
    }
}

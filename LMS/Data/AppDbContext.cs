using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt): base(opt) { }
       public DbSet<Book> Books { get; set; }
       public DbSet<Borrowing> Borrowings { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(m => m.Email).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Borrowing>().HasOne(b => b.Book).WithMany(B => B.Borrowings).HasForeignKey(b => b.BookId);
            modelBuilder.Entity<Borrowing>().HasOne(b => b.Member).WithMany(m => m.Borrowings).HasForeignKey(b => b.MemberId);
            modelBuilder.Entity<Book>().HasOne(b => b.Category).WithMany(c => c.Books).HasForeignKey(b => b.CategoryId);
            modelBuilder.Entity<User>().HasIndex(u=>u.UserName).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}

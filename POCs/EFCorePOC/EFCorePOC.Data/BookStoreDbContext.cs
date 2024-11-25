using EFCorePOC.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.Marshalling;

namespace EFCorePOC.Data
{
    //How this db will work
    //Basically, this will be an application, that will contain data from multiple websites, about what books are available so the user will be able to see 
    //where he can find a specific book.
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Website> Websites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(a => a.Author)
               .WithMany(b => b.Books)
               .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<Book>().HasOne(c => c.Publisher)
               .WithMany(b => b.Books)
               .HasForeignKey(c => c.PublisherId);


            modelBuilder.Entity<Book>().HasOne(c => c.Website)
               .WithMany(b => b.Books)
               .HasForeignKey(c => c.WebsiteId);

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
             .HasOne(bc => bc.Book)
             .WithMany(b => b.BookCategories)
             .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);


            modelBuilder.Entity<Author>().HasData(
                new Author { Id = "AuthorId1", Name = "AuthorName1"},
                new Author { Id = "AuthorId2", Name = "AuthorName2" },
                new Author { Id = "AuthorId3", Name = "AuthorName3" },
                new Author { Id = "AuthorId4", Name = "AuthorName4" },
                new Author { Id = "AuthorId5", Name = "AuthorName5" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = "CategoryId1", Name = "CategoryName1" },
                new Category { Id = "CategoryId2", Name = "CategoryName2" },
                new Category { Id = "CategoryId3", Name = "CategoryName3" },
                new Category { Id = "CategoryId4", Name = "CategoryName4" },
                new Category { Id = "CategoryId5", Name = "CategoryName5" }
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = "PublisherId1", Name = "PublisherName1" },
                new Publisher { Id = "PublisherId2", Name = "PublisherName2" },
                new Publisher { Id = "PublisherId3", Name = "PublisherName3" },
                new Publisher { Id = "PublisherId4", Name = "PublisherName4" },
                new Publisher { Id = "PublisherId5", Name = "PublisherName5" }
                );

            modelBuilder.Entity<Website>().HasData(
                new Website { Id = "WebsiteId1", Name = "WebsiteName1", AddressUrl = "WebsiteUrl1" },
                new Website { Id = "WebsiteId2", Name = "WebsiteName2", AddressUrl = "WebsiteUrl2" },
                new Website { Id = "WebsiteId3", Name = "WebsiteName3", AddressUrl = "WebsiteUrl3" },
                new Website { Id = "WebsiteId4", Name = "WebsiteName4", AddressUrl = "WebsiteUrl4" },
                new Website { Id = "WebsiteId5", Name = "WebsiteName5", AddressUrl = "WebsiteUrl5" }
                );

            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory { BookId = "BookId1", CategoryId = "CategoryId1" },
                new BookCategory { BookId = "BookId2", CategoryId = "CategoryId2" },
                new BookCategory { BookId = "BookId3", CategoryId = "CategoryId3" },
                new BookCategory { BookId = "BookId4", CategoryId = "CategoryId4" },
                new BookCategory { BookId = "BookId5", CategoryId = "CategoryId1" },
                new BookCategory { BookId = "BookId1", CategoryId = "CategoryId2" },
                new BookCategory { BookId = "BookId1", CategoryId = "CategoryId3" },
                new BookCategory { BookId = "BookId2", CategoryId = "CategoryId5" }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = "BookId1", Title = "BookTitle1", Description = "BookDescription1", AuthorId = "AuthorId1", WebsiteId = "WebsiteId1" },
                new Book { Id = "BookId2", Title = "BookTitle2", Description = "BookDescription2", AuthorId = "AuthorId2", WebsiteId = "WebsiteId2" },
                new Book { Id = "BookId3", Title = "BookTitle3", Description = "BookDescription3", AuthorId = "AuthorId3", WebsiteId = "WebsiteId3" },
                new Book { Id = "BookId4", Title = "BookTitle4", Description = "BookDescription4", AuthorId = "AuthorId4", WebsiteId = "WebsiteId4" },
                new Book { Id = "BookId5", Title = "BookTitle5", Description = "BookDescription5", AuthorId = "AuthorId5", WebsiteId = "WebsiteId5" }
                );
        }


    }
}

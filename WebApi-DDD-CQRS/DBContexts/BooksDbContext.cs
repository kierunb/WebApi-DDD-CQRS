using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApi_DDD_CQRS.DbContexts
{

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public BookShippingDetail BookShippingDetail { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }

    public class BookShippingDetail
    {
        public int BookShippingDetailId { get; set; }
        public string ProductDimensions { get; set; }
        public string ShippingWeight { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }

    public class BooksDbContext : DbContext
    {
        private readonly IConfiguration config;

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookShippingDetail> BookShippingDetails { get; set; }



        //public BooksDbContext(DbContextOptions<BooksDbContext> options)
        //   : base(options)
        //{
        //}

        public BooksDbContext(IConfiguration config)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(this.config.GetConnectionString("LocalSqlServer"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // model configuration
        }
    }
}

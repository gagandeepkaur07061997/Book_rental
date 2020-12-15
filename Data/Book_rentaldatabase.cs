using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book_rental.Models;

namespace Book_rental.Data
{
    public class Book_rentaldatabase : DbContext
    {
        public Book_rentaldatabase (DbContextOptions<Book_rentaldatabase> options)
            : base(options)
        {
        }

        public DbSet<Book_rental.Models.Author> Author { get; set; }

        public DbSet<Book_rental.Models.Publisher_detail> Publisher_detail { get; set; }

        public DbSet<Book_rental.Models.Books_detail> Books_detail { get; set; }

        public DbSet<Book_rental.Models.Publication_detail> Publication_detail { get; set; }
    }
}

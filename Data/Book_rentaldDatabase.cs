using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book_rental.Models;

namespace Book_rental.Data
{
    public class Book_rentaldDatabase : DbContext
    {
        public Book_rentaldDatabase (DbContextOptions<Book_rentaldDatabase> options)
            : base(options)
        {
        }

        public DbSet<Book_rental.Models.Author> Author { get; set; }

        public DbSet<Book_rental.Models.Publisher_detail> Publisher_detail { get; set; }

        public DbSet<Book_rental.Models.Books_detail> Books_detail { get; set; }

        public DbSet<Book_rental.Models.Publication_detail> Publication_detail { get; set; }
    }
}

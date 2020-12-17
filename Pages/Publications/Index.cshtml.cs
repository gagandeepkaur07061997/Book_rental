using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Publications
{
    public class IndexModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldDatabase _context;

        public IndexModel(Book_rental.Data.Book_rentaldDatabase context)
        {
            _context = context;
        }

        public IList<Publication_detail> Publication_detail { get;set; }

        public async Task OnGetAsync()
        {
            Publication_detail = await _context.Publication_detail
                .Include(p => p.Books_detail)
                .Include(p => p.Publisher_detail).ToListAsync();
        }
    }
}

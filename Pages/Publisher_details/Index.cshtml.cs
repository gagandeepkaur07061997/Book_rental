using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Publisher_details
{
    public class IndexModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldatabase _context;

        public IndexModel(Book_rental.Data.Book_rentaldatabase context)
        {
            _context = context;
        }

        public IList<Publisher_detail> Publisher_detail { get;set; }

        public async Task OnGetAsync()
        {
            Publisher_detail = await _context.Publisher_detail.ToListAsync();
        }
    }
}

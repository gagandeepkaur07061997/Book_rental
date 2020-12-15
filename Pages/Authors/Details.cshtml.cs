using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldatabase _context;

        public DetailsModel(Book_rental.Data.Book_rentaldatabase context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Author.FirstOrDefaultAsync(m => m.Id == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

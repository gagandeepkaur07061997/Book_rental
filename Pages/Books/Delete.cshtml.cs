using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldDatabase _context;

        public DeleteModel(Book_rental.Data.Book_rentaldDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Books_detail Books_detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books_detail = await _context.Books_detail
                .Include(b => b.Author).FirstOrDefaultAsync(m => m.Id == id);

            if (Books_detail == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books_detail = await _context.Books_detail.FindAsync(id);

            if (Books_detail != null)
            {
                _context.Books_detail.Remove(Books_detail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

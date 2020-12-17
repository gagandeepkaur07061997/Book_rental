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
    public class DeleteModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldDatabase _context;

        public DeleteModel(Book_rental.Data.Book_rentaldDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Publication_detail Publication_detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publication_detail = await _context.Publication_detail
                .Include(p => p.Books_detail)
                .Include(p => p.Publisher_detail).FirstOrDefaultAsync(m => m.Id == id);

            if (Publication_detail == null)
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

            Publication_detail = await _context.Publication_detail.FindAsync(id);

            if (Publication_detail != null)
            {
                _context.Publication_detail.Remove(Publication_detail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

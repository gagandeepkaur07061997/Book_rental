using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Publications
{
    public class EditModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldDatabase _context;

        public EditModel(Book_rental.Data.Book_rentaldDatabase context)
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
           ViewData["Books_detailId"] = new SelectList(_context.Books_detail, "Id", "Tittle");
           ViewData["Publisher_detailId"] = new SelectList(_context.Publisher_detail, "Id", "Publisher_Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Publication_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Publication_detailExists(Publication_detail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Publication_detailExists(int id)
        {
            return _context.Publication_detail.Any(e => e.Id == id);
        }
    }
}

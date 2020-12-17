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

namespace Book_rental.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldDatabase _context;

        public EditModel(Book_rental.Data.Book_rentaldDatabase context)
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
           ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Email_Id");
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

            _context.Attach(Books_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Books_detailExists(Books_detail.Id))
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

        private bool Books_detailExists(int id)
        {
            return _context.Books_detail.Any(e => e.Id == id);
        }
    }
}

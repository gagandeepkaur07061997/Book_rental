using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldDatabase _context;

        public CreateModel(Book_rental.Data.Book_rentaldDatabase context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Email_Id");
            return Page();
        }

        [BindProperty]
        public Books_detail Books_detail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books_detail.Add(Books_detail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

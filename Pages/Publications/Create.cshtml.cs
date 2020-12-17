using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Publications
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
        ViewData["Books_detailId"] = new SelectList(_context.Books_detail, "Id", "Tittle");
        ViewData["Publisher_detailId"] = new SelectList(_context.Publisher_detail, "Id", "Publisher_Name");
            return Page();
        }

        [BindProperty]
        public Publication_detail Publication_detail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publication_detail.Add(Publication_detail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

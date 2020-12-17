using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Publishers
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
            return Page();
        }

        [BindProperty]
        public Publisher_detail Publisher_detail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher_detail.Add(Publisher_detail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

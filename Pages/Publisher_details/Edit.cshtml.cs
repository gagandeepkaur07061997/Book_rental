﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_rental.Data;
using Book_rental.Models;

namespace Book_rental.Pages.Publisher_details
{
    public class EditModel : PageModel
    {
        private readonly Book_rental.Data.Book_rentaldatabase _context;

        public EditModel(Book_rental.Data.Book_rentaldatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Publisher_detail Publisher_detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher_detail = await _context.Publisher_detail.FirstOrDefaultAsync(m => m.Id == id);

            if (Publisher_detail == null)
            {
                return NotFound();
            }
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

            _context.Attach(Publisher_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Publisher_detailExists(Publisher_detail.Id))
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

        private bool Publisher_detailExists(int id)
        {
            return _context.Publisher_detail.Any(e => e.Id == id);
        }
    }
}

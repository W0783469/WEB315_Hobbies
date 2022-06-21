using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB315_Hobbies.Models;

namespace WEB315_Hobbies.Pages_hobbies
{
    public class EditModel : PageModel
    {
        private readonly WEB315_HobbiesContext _context;

        public EditModel(WEB315_HobbiesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public hobbies hobbies { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            hobbies = await _context.hobbies.FirstOrDefaultAsync(m => m.ID == id);

            if (hobbies == null)
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

            _context.Attach(hobbies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hobbiesExists(hobbies.ID))
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

        private bool hobbiesExists(int id)
        {
            return _context.hobbies.Any(e => e.ID == id);
        }
    }
}

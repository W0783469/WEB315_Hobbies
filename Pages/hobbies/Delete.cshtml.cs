using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB315_Hobbies.Models;

namespace WEB315_Hobbies.Pages_hobbies
{
    public class DeleteModel : PageModel
    {
        private readonly WEB315_HobbiesContext _context;

        public DeleteModel(WEB315_HobbiesContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            hobbies = await _context.hobbies.FindAsync(id);

            if (hobbies != null)
            {
                _context.hobbies.Remove(hobbies);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

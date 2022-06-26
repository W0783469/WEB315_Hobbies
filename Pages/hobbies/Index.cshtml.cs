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
    public class IndexModel : PageModel
    {
        private readonly WEB315_HobbiesContext _context;

        public IndexModel(WEB315_HobbiesContext context)
        {
            _context = context;
        }

        public IList<hobbies> hobbies { get;set; }

        public async Task OnGetAsync()
        {
            hobbies = await _context.hobbies.ToListAsync();
        }
    }
}

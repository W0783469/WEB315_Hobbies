using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Title { get; set; }
        [BindProperty(SupportsGet = true)]
        public string HobbiesTitle { get; set; }

        public async Task OnGetAsync()
        {
           // Use LINQ to get list of genres.
            IQueryable<string> currentTitleQuery = from h in _context.hobbies
                                            orderby h.CurrentTitle
                                            select h.CurrentTitle;
        var hobbies = from h in _context.hobbies
                        select h;

            if (!string.IsNullOrEmpty(SearchString))
            {
                hobbies = hobbies.Where(s => s.FullName.ToLower().Contains(SearchString.ToLower()));
            }

            if (!string.IsNullOrEmpty(hobbiesCurrentTitle))
            {
                hobbies = hobbies.Where(x => x.CurrentTitle == hobbiesCurrentTitle);
            }
            CurrentTitles = new SelectList(await currentTitleQuery.Distinct().ToListAsync());
            hobbies = await hobbies.ToListAsync();
        }
    }
}

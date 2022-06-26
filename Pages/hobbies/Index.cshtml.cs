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
            IQueryable<string> TitleQuery = from h in _context.hobbies
                                            orderby h.Title
                                            select h.Title;
        var hobbies = from h in _context.hobbies
                        select h;

            if (!string.IsNullOrEmpty(SearchString))
            {
                hobbies = hobbies.Where(s => s.FullName.ToLower().Contains(SearchString.ToLower()));
            }

            if (!string.IsNullOrEmpty(hobbiesTitle))
            {
                hobbies = hobbies.Where(x => x.Title == hobbiesTitle);
            }
            Title = new SelectList(await TitleQuery.Distinct().ToListAsync());
            hobbies = await hobbies.ToListAsync();
        }
    }
}

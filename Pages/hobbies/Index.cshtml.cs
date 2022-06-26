using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB315_Hobbies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public SelectList Hobby { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Travellinghobby { get; set; }
  
        public async Task OnGetAsync()
        {
              IQueryable<string> hobbieQuery = from m in _context.hobbies
                                    orderby m.Title
                                    select m.Title;

 
var hobbie = from m in _context.hobbies
                 select m;
     
                 
if (!string.IsNullOrEmpty(SearchString))
    {
        hobbie = hobbie.Where(s => s.Title.Contains(SearchString));
    }
   
  
     if (!string.IsNullOrEmpty(Travellinghobby))
    {
        hobbie = hobbie.Where(x => x.Title == Travellinghobby);
    }
    
    Hobby = new SelectList(await hobbieQuery.Distinct().ToListAsync());
    hobbies = await hobbie.ToListAsync();
           
        }
    }
}

        

         
    
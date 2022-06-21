using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB315_Hobbies.Models;

    public class WEB315_HobbiesContext : DbContext
    {
        public WEB315_HobbiesContext (DbContextOptions<WEB315_HobbiesContext> options)
            : base(options)
        {
        }

        public DbSet<WEB315_Hobbies.Models.hobbies> hobbies { get; set; }
    }

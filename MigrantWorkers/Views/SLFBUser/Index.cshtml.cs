using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MigrantWorkers.Data;
using MigrantWorkers.Models;

namespace MigrantWorkers.Views.SLFBUser
{
    public class IndexModel : PageModel
    {
        private readonly MigrantWorkers.Data.ApplicationDbContext _context;

        public IndexModel(MigrantWorkers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SLFB_User> SLFB_User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SFBUsers != null)
            {
                SLFB_User = await _context.SFBUsers
                .Include(s => s.User).ToListAsync();
            }
        }
    }
}

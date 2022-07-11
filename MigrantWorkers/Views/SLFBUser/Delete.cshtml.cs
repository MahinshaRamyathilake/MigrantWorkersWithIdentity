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
    public class DeleteModel : PageModel
    {
        private readonly MigrantWorkers.Data.ApplicationDbContext _context;

        public DeleteModel(MigrantWorkers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SLFB_User SLFB_User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SLFBUsers == null)
            {
                return NotFound();
            }

            var slfb_user = await _context.SLFBUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (slfb_user == null)
            {
                return NotFound();
            }
            else
            {
                SLFB_User = slfb_user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SLFBUsers == null)
            {
                return NotFound();
            }
            var slfb_user = await _context.SLFBUsers.FindAsync(id);

            if (slfb_user != null)
            {
                SLFB_User = slfb_user;
                _context.SLFBUsers.Remove(SLFB_User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

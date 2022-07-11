using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MigrantWorkers.Data;
using MigrantWorkers.Models;

namespace MigrantWorkers.Views.SLFBUser
{
    public class EditModel : PageModel
    {
        private readonly MigrantWorkers.Data.ApplicationDbContext _context;

        public EditModel(MigrantWorkers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SLFB_User SLFB_User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SFBUsers == null)
            {
                return NotFound();
            }

            var slfb_user =  await _context.SFBUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (slfb_user == null)
            {
                return NotFound();
            }
            SLFB_User = slfb_user;
           ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName");
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

            _context.Attach(SLFB_User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SLFB_UserExists(SLFB_User.Id))
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

        private bool SLFB_UserExists(int id)
        {
          return (_context.SFBUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

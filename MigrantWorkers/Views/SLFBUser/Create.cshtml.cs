using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MigrantWorkers.Data;
using MigrantWorkers.Models;

namespace MigrantWorkers.Views.SLFBUser
{
    public class CreateModel : PageModel
    {
        private readonly MigrantWorkers.Data.ApplicationDbContext _context;

        public CreateModel(MigrantWorkers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserID"] = new SelectList(_context.Users, "Id", "UserName");
            return Page();
        }

        [BindProperty]
        public SLFB_User SLFB_User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SFBUsers == null || SLFB_User == null)
            {
                return Page();
            }

            _context.SFBUsers.Add(SLFB_User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

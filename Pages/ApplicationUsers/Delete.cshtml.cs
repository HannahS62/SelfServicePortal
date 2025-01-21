using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SelfServicePortal.Data;
using SelfServicePortal.Models;

namespace SelfServicePortal.Pages_ApplicationUsers
{
    public class DeleteModel : PageModel
    {
        private readonly SelfServicePortal.Data.SelfServicePortalContext _context;

        public DeleteModel(SelfServicePortal.Data.SelfServicePortalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUsers ApplicationUsers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationusers = await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (applicationusers is not null)
            {
                ApplicationUsers = applicationusers;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationusers = await _context.ApplicationUsers.FindAsync(id);
            if (applicationusers != null)
            {
                ApplicationUsers = applicationusers;
                _context.ApplicationUsers.Remove(ApplicationUsers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

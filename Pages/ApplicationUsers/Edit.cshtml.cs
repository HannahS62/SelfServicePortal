using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SelfServicePortal.Data;
using SelfServicePortal.Models;

namespace SelfServicePortal.Pages_ApplicationUsers
{
    public class EditModel : PageModel
    {
        private readonly SelfServicePortal.Data.SelfServicePortalContext _context;

        public EditModel(SelfServicePortal.Data.SelfServicePortalContext context)
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

            var applicationusers =  await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (applicationusers == null)
            {
                return NotFound();
            }
            ApplicationUsers = applicationusers;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicationUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUsersExists(ApplicationUsers.Id))
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

        private bool ApplicationUsersExists(int id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}

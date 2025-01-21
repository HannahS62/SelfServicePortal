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
    public class DetailsModel : PageModel
    {
        private readonly SelfServicePortal.Data.SelfServicePortalContext _context;

        public DetailsModel(SelfServicePortal.Data.SelfServicePortalContext context)
        {
            _context = context;
        }

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
    }
}

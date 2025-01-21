using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SelfServicePortal.Data;
using SelfServicePortal.Models;

namespace SelfServicePortal.Pages_DepotMapping
{
    public class DeleteModel : PageModel
    {
        private readonly SelfServicePortal.Data.SelfServicePortalContext _context;

        public DeleteModel(SelfServicePortal.Data.SelfServicePortalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepotMapping DepotMapping { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depotmapping = await _context.DepotMapping.FirstOrDefaultAsync(m => m.Id == id);

            if (depotmapping is not null)
            {
                DepotMapping = depotmapping;

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

            var depotmapping = await _context.DepotMapping.FindAsync(id);
            if (depotmapping != null)
            {
                DepotMapping = depotmapping;
                _context.DepotMapping.Remove(DepotMapping);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

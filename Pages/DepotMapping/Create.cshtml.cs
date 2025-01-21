using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelfServicePortal.Data;
using SelfServicePortal.Models;

namespace SelfServicePortal.Pages_DepotMapping
{
    public class CreateModel : PageModel
    {
        private readonly SelfServicePortal.Data.SelfServicePortalContext _context;

        public CreateModel(SelfServicePortal.Data.SelfServicePortalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DepotMapping DepotMapping { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DepotMapping.Add(DepotMapping);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

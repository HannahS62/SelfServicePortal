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
    public class IndexModel : PageModel
    {
        private readonly SelfServicePortal.Data.SelfServicePortalContext _context;

        public IndexModel(SelfServicePortal.Data.SelfServicePortalContext context)
        {
            _context = context;
        }

        public IList<ApplicationUsers> ApplicationUsers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ApplicationUsers = await _context.ApplicationUsers.ToListAsync();
        }
    }
}

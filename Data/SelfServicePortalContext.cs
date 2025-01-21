using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfServicePortal.Models;

namespace SelfServicePortal.Data
{
    public class SelfServicePortalContext : DbContext
    {
        public SelfServicePortalContext (DbContextOptions<SelfServicePortalContext> options)
            : base(options)
        {
        }


        public DbSet<SelfServicePortal.Models.ApplicationUsers> ApplicationUsers { get; set; } = default!;
        public DbSet<SelfServicePortal.Models.DepotMapping> DepotMapping { get; set; } = default!;
    }
}

using Microsoft.EntityFrameworkCore;
using SelfServicePortal.Models;

namespace SelfServicePortal.Data;

public static class SeedDataDepotMapping
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SelfServicePortalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<SelfServicePortalContext>>()))
        {
            
             if (context == null || context.DepotMapping == null)
            {
                throw new ArgumentNullException("Null SelfServicePortalContext");
            }

            // Look for any depot items.
            if (context.DepotMapping.Any())
            {
                return;   // DB has been seeded
            }

            context.DepotMapping.AddRange(
            new DepotMapping
            {
                Id = 1,
                ADGroup = 1011234,
                Depot = "Manchester"
            },
            new DepotMapping
            {
                Id = 2,
                ADGroup = 1021234,
                Depot = "Norwich"
            },
            new DepotMapping
            {
                Id = 3,
                ADGroup = 1031234,
                Depot = "Heathrow"
            },
            new DepotMapping
            {
                Id = 4,
                ADGroup = 1041234,
                Depot = "Shrewsbury"
            },
            new DepotMapping
            {
                Id = 5,
                ADGroup = 1051234,
                Depot = "Peterborough"
            },
            new DepotMapping
            {
                Id = 6,
                ADGroup = 1061234,
                Depot = "Thetford"
            }
        );
                    context.SaveChanges();
    }
    }
}

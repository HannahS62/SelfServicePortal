using Microsoft.EntityFrameworkCore;
using SelfServicePortal.Models;

namespace SelfServicePortal.Data;

public static class SeedDataAppUsers
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SelfServicePortalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<SelfServicePortalContext>>()))
        {
            
             if (context == null || context.ApplicationUsers == null)
            {
                throw new ArgumentNullException("Null SelfServicePortalContext");
            }

            // Look for any appuser items.
            if (context.ApplicationUsers.Any())
            {
                return;   // DB has been seeded
            }

            context.ApplicationUsers.AddRange(
               new ApplicationUsers
            {
                Id = 1,
                UserName = "Smith, Hannah",
                UserEmail = "hannah.smith@em.com",
                Appgroup = "SecOpAdmin",
                AdGroup = null
            },
            new ApplicationUsers
            {
                Id = 2,
                UserName = "Eaton, Mark",
                UserEmail = "mark.eatom@em.com",
                Appgroup = "SecOpAdmin",
                AdGroup = null
            },
            new ApplicationUsers
            {
                Id = 3,
                UserName = "Roger, Joanna",
                UserEmail = "joanna.rogers@em.com",
                Appgroup = "SecOpAll",
                AdGroup = null
            },
            new ApplicationUsers
            {
                Id = 4,
                UserName = "Hicken, Michelle",
                UserEmail = "michelle.hicken@em.com",
                Appgroup = "SecOpStandard",
                AdGroup = "1041234"
            }

                );
            context.SaveChanges();
       }
    }
}

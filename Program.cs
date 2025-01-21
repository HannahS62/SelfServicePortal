using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SelfServicePortal.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SelfServicePortalContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SelfServicePortalContext") ?? throw new InvalidOperationException("Connection string 'SelfServicePortalContext' not found.")));

var app = builder.Build();

//seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SelfServicePortalContext>();

    // Ensures the database is deleted and recreated each time
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    //Seed data
    SeedDataAppUsers.Initialize(services);
    SeedDataDepotMapping.Initialize(services);
  
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}
app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.

app.UseStaticFiles(); // enables static files, such as HTML, CSS, images and JavaScript to be serverd.

app.UseRouting(); // adds route matching the middleware pipeline

app.UseAuthorization(); // authorises a user to access secure resources (not currently being used in this application)

app.MapRazorPages(); // enpoint configuration routing for Razor pages

app.Run(); // Runs the application 

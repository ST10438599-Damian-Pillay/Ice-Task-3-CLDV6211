using Microsoft.EntityFrameworkCore;
using IceTask3.Data; // <-- This must match the namespace of AppDbContext


var builder = WebApplication.CreateBuilder(args);

// Register MVC controllers with views
builder.Services.AddControllersWithViews();

// Register your AppDbContext (formerly DBContext)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Needed for serving CSS/JS/images
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

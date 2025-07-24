using Microsoft.EntityFrameworkCore;
using ValidationsMaster_MVC_Core_8.Data;

var builder = WebApplication.CreateBuilder(args);

//  Add services to the container
builder.Services.AddControllersWithViews();

//  Add DB context for EF Core
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//  Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//  Set default route to User/Register
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

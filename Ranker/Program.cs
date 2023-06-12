using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ranker.Areas.Identity.Data;
using Ranker.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RankerContextConnection") ?? throw new InvalidOperationException("Connection string 'RankerContextConnection' not found.");

builder.Services.AddDbContext<RankerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<RankerUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<RankerContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=RegLog}/{id?}");

app.MapRazorPages();
app.Run();

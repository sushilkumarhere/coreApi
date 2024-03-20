
using exceltosql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Medisuite_rel2Context>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
//builder.Services.AddDbContext<ApplicationDBcontext>(options => options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


//app.MapGet("/", () => "Hello World!");


// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

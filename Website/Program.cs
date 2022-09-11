using Website.Models.Interfaces;
using Website.Models;
using Website.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton<IUserLogin, UserRepository>();
builder.Services.AddSingleton<IContentData, ContentDataRepository>();
builder.Services.AddSingleton<ITherapist, TherapistRepository>();
builder.Services.AddSingleton<IAdmin, AdminRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

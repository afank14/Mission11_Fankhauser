using Microsoft.EntityFrameworkCore;
using Mission11_Fankhauser.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the options for using Sqlite with the database
builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookConnection"]);
});

// Add the scoped repository
builder.Services.AddScoped<IBooksRepository, EFBooksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Update the route so it says "Books/1" instead of ?pageNum=1 in the URL
app.MapControllerRoute("pagination", "Books/{pageNum}", new {Controller = "Home", action = "Index"});
app.MapDefaultControllerRoute();

app.Run();
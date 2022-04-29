using Microsoft.EntityFrameworkCore;
using HR.Models.db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IkkmContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("HRServer"))
    );

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 
app.MapControllerRoute(

    name: "add_emp",
    pattern: "{controller=Home}/{action=AddEmployee}/{id?}");

app.MapControllerRoute(
     name: "hr",
     pattern: "{controller=Home}/{action=hr}/{id?}"); 

app.MapControllerRoute(
       name: "empList",
       pattern: "{controller=Employees}/{action=Index}/{id?}");

app.MapControllerRoute(
       name: "empDetail",
       pattern: "{controller=Employees}/{action=Details}/{id?}");

app.MapControllerRoute(
       name: "empCreate",
       pattern: "{controller=Employees}/{action=Create}/{id?}");

app.MapControllerRoute(
       name: "empEdit",
       pattern: "{controller=Employees}/{action=Edit}/{id?}"); 


app.MapControllerRoute(
       name: "el",
       pattern: "{controller=Employees}/{action=Delete}/{id?}");


app.MapControllerRoute(
       name: "error",
       pattern: "{controller=Error}/{action=Index}/{id?}");
app.Run();

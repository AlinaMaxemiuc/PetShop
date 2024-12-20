using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Repositories.Abonaments;
using exp.Template.Infrastructure.Repositories.Animals;
using exp.Template.Infrastructure.Repositories.Comenzi;
using exp.Template.Infrastructure.Repositories.Discounts;
using exp.Template.Infrastructure.Repositories.Foods;
using exp.Template.Infrastructure.Repositories.Livrarii;
using exp.Template.Infrastructure.Repositories.Users;


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AnimalsFoodContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IUtilizatorRepository, UtilizatorRepository>();
builder.Services.AddScoped<IHranaRepository, HranaRepository>();
builder.Services.AddScoped<IAbonamentRepository, AbonamentRepository>();
builder.Services.AddScoped<IComandaRepository, ComandaRepository>();
builder.Services.AddScoped<ILivrariRepository, LivrariRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

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
    name: "animal",
    pattern: "Animal/{action=Index}/{id?}",
    defaults: new { controller = "Animal" });

app.MapControllerRoute(
    name: "utilizator",
    pattern: "Utilizator/{action=Index}/{id?}",
    defaults: new { controller = "Utilizator" });

app.MapControllerRoute(
    name: "abonament",
    pattern: "Abonament/{action=Index}/{id?}",
    defaults: new { controller = "Abonament" });

app.MapControllerRoute(
    name: "comanda",
    pattern: "Comanda/{action=Index}/{id?}",
    defaults: new { controller = "Comanda" });

app.MapControllerRoute(
    name: "hrana",
    pattern: "Hrana/{action=Index}/{id?}",
    defaults: new { controller = "Hrana" });

app.MapControllerRoute(
    name: "discount",
    pattern: "Discount/{action=Index}/{id?}",
    defaults: new { controller = "Discount" });

app.MapControllerRoute(
    name: "livrari",
    pattern: "Livrari/{action=Index}/{id?}",
    defaults: new { controller = "Livrari" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

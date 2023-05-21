using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Repository;
using Repository.FoodRepo;
using Service.FoodSer;
using Repository.ReustarantRepo;
using Service.ReustarantSer;
using Data;
using Repository.ShopCartRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
   
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


builder.Services.AddScoped(typeof(IFoodRepository), typeof(FoodRepository));

builder.Services.AddTransient<IFoodService, FoodService>();

builder.Services.AddScoped(typeof(IReustarantRepository), typeof(ReustarantRepository));

builder.Services.AddTransient<IReustarantService, ReustarantService>();

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCartRepository.GetCart(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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
app.UseSession();   
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Privacy}/{id?}");

app.Run();

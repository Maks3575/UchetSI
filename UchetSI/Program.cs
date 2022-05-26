using Microsoft.EntityFrameworkCore;
using UchetSI.Data.Interfaces;
using UchetSI.Data.Repositories;
using UchetSI.Data.Models;
using UchetSI.Data;

var builder = WebApplication.CreateBuilder(args);
// получаем строку подключения из файла конфигурации





// добавляем контекст ApplicationContext в качестве сервиса в приложение
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddTransient<ILocation, LocationRepository>();
builder.Services.AddTransient<ITypeLocation, TypeLocationRepository>();
builder.Services.AddTransient<IFillTestData, FillTestData>();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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
    
//using (var scope = app.CreateScope())
//{
//    ApplicationContext content = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
////    DBObjects.Initial(content);
//}
app.Run();

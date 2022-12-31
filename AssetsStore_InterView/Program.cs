using AssetsStore.Models.DataAcces.Helper;
using AssetsStore.Models.DataAcces.Logic;
using AssetsStore_InterView.BussinessLayer.Helper;
using AssetsStore_InterView.BussinessLayer.Logic;
using AssetsStore_InterView.Models.DataAcces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


   // Auto Mapper Configurations
   #region Auto Mapper
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new Mapping());
        });
        IMapper mapper = mapperConfig.CreateMapper();
 builder.Services.AddSingleton(mapper);
#endregion
// dependance injection 
builder.Services.AddTransient(typeof(IRepositoryHelper<>), typeof(RepositoryLogic<>));
builder.Services.AddTransient<AssetContext , AssetContext>();
builder.Services.AddTransient<IAssetHelper, AssetLogic>();
builder.Services.AddTransient<IAttributeHelper, AttributeLogic>();




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

app.Run();

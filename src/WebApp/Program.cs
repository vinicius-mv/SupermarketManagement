using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Plugins.DataStore.InMemory;
using System.Globalization;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Set Culture Info
var cultureInfo = new CultureInfo("en-US");
cultureInfo.NumberFormat.CurrencySymbol = "$";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Dependency Injection for In-Memory Data Store
builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

// Dependency Injection for Use Cases and Repositories
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryIdUseCase, ViewProductsByCategoryIdUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTransactionsByDateUseCase, GetTransactionsByDateUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using Microsoft.Extensions.Options;

namespace MultiShop.Catalog.Settings;

public static class ConfigurationSettings
{
    public static void ContainerExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductDetailService, ProductDetailService>();
        services.AddScoped<IProductImageService, ProductImageService>();

        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings")); //appsettings.json daki databasesettings kısmını tanımladık

        //IDatabasesettings ınterfaceini addscoped olarak databasesettingsteki serviceslerere eşleştirdık.
        services.AddScoped<IDatabaseSettings>(sp =>
        {
            return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        });

    }
}

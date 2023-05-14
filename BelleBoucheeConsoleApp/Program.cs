
using BelleBoucheeConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

// Create the service container
var builder = new ServiceCollection()
    .AddSingleton<IMainService, MainService>()
    .AddTransient<IDisplayService, DisplayService>()
    .AddSingleton<IProductService, ProductService>()
    .AddSingleton<IOrderService , OrderService>()
    .AddSingleton<IOrderHasProductsService, OrderHasProductsService>()
    .AddSingleton<IClientService, ClientService>()
    

    .BuildServiceProvider();
var  app = builder.GetRequiredService<IMainService>();

app.start();

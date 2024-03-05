using Carshop.Core.Entities;
using CarShop.Infrastructure.Data;
using CarShop.Infrastructure.Repositories;
using CarShop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CarShop.UI
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            var mainWindowModel = _serviceProvider.GetRequiredService<MainWindowModel>();
            var mainWindow = new MainWindow(mainWindowModel);
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var optionBuilder = new DbContextOptionsBuilder<CarShopDbContext>();
            // TODO Environment Variables
            optionBuilder.UseSqlServer("Data Source=RYZEN\\SQLEXPRESS;Initial Catalog=CarShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            var dbContext = new CarShopDbContext(optionBuilder.Options);

            services
                .AddSingleton<ICarShopContext>(dbContext)
                .AddDbContext<CarShopDbContext>(options => options.UseSqlServer("Data Source=RYZEN\\SQLEXPRESS;Initial Catalog=CarShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                .AddSingleton<IGenericRepository<Client>, GenericRepository<Client>>()
                .AddSingleton<IGenericRepository<Car>, GenericRepository<Car>>()
                .AddSingleton<MainWindowModel>(provider =>
                    new MainWindowModel(
                        provider.GetRequiredService<IGenericRepository<Car>>(),
                        provider.GetRequiredService<IGenericRepository<Client>>()));
        }
    }
}

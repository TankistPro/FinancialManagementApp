using FinancialManagementApp.Infrastructure.Mapper;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Layouts;
using FinancialManagementApp.Pages;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace FinancialManagementApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMapper));
            services.AddScoped<MainWindow>();
            services.AddScoped<AddWalletHistoryWindow>();

            services.AddScoped<AuthPage>();
            services.AddScoped<RegistrationPage>();
            services.AddScoped<HomeLayout>();

            services.AddSingleton<HomeLayoutVM>();
            services.AddSingleton<WalletHistoryVM>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IWalletService, WalletService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {

            var mainWindow = serviceProvider.GetService<MainWindow>();

            mainWindow?.Show();

        }
    }

}

using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Domain.Interfaces;
using Phoneshop.WinForms.Logic;
using Phoneshop.WinForms.Logic.Repositories;
using System;
using System.Windows.Forms;

namespace Phoneshop.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                Application.Run(serviceProvider.GetRequiredService<PhoneOverview>());
        }


        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped(typeof(IRepository<>), typeof(AdoRepository<>));

            services.AddScoped<PhoneOverview>();
        }
    }
}

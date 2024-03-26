using Microsoft.Extensions.DependencyInjection;
using SmartSchool.Extentions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SmartSchool
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
            services.AddDependencyInjection();
            services.AddDataBase();
            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();
        }
        private void OnStartup(object sender, EventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}

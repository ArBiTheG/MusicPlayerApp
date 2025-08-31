using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicPlayerApp.Infrastructure;
using MusicPlayerApp.UI.ViewModels;
using MusicPlayerApp.UI.Views;
using System;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace MusicPlayerApp.UI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var host = Host.CreateDefaultBuilder(desktop.Args)
                    .ConfigureAppConfiguration(ConfigureConfigs)
                    .ConfigureServices(ConfigureServices)
                    .Build();

                host.Start();

                MainWindow window = host.Services.GetRequiredService<MainWindow>();
                MainWindowViewModel viewModel = host.Services.GetRequiredService<MainWindowViewModel>();
                window.DataContext = viewModel;

                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();

                desktop.MainWindow = window;
            }

            base.OnFrameworkInitializationCompleted();
        }


        private void ConfigureConfigs(HostBuilderContext context, IConfigurationBuilder config) 
        { 

        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddInfrastructure();

            services.AddSingleton<MainWindow>();

            services.AddSingleton<MainWindowViewModel>();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}
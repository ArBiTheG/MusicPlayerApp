using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicPlayerApp.HostBuilders;
using MusicPlayerApp.ViewModels;
using MusicPlayerApp.Views;
using System.Linq;

namespace MusicPlayerApp
{
    public partial class App : Application
    {
        IHost? _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddServices()
                .AddStores()
                .AddViews()
                .AddViewModels().Build();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            _host?.Start();

            MainWindow mainWindow = _host?.Services.GetRequiredService<MainWindow>() ?? new MainWindow();
            MainWindowViewModel mainWindowViewModel = _host?.Services.GetRequiredService<MainWindowViewModel>() ?? new MainWindowViewModel();
            mainWindow.DataContext = mainWindowViewModel;

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
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
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LabWorkGPT1.ViewModels;
using LabWorkGPT1.Views;

namespace LabWorkGPT1
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
                desktop.MainWindow = new LoginWindow
                {
                    DataContext = new LoginViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

    }
}
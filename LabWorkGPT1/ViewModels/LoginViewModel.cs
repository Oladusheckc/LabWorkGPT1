using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using LabWorkGPT1.Views;
using ReactiveUI;
using System.Reactive;
using System.Security.AccessControl;

namespace LabWorkGPT1.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _rightLogin = "111";
        private string _rightPassword = "222";
        private string _username;
        private string _password;
        private string _loginResult;

        private readonly ObservableAsPropertyHelper<bool> _canLogin;

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string LoginResult
        {
            get => _loginResult;
            private set => this.RaiseAndSetIfChanged(ref _loginResult, value);
        }
        public bool CanLogin => _canLogin.Value;

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public LoginViewModel(IClassicDesktopStyleApplicationLifetime desktop)
        {
            this.WhenAnyValue(x => x.Username, x => x.Password,
                              (user, pass) => !string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass))
                .ToProperty(this, x => x.CanLogin, out _canLogin);
            LoginCommand = ReactiveCommand.Create(
            () =>
            {
                if (Username == _rightLogin && Password == _rightPassword)
                {
                    LoginResult = "Успешный вход!";
                    // Здесь можно переключить окно или вызвать навигацию
                    Window cW = desktop.MainWindow;
                    desktop.MainWindow = new NotesWindow
                    {
                        DataContext = new NotesViewModel(),
                    };
                    desktop.MainWindow.Show();
                    cW.Close();

                }
                else
                {
                    LoginResult = "Неверный логин или пароль";
                }
            });
        }
    }
}

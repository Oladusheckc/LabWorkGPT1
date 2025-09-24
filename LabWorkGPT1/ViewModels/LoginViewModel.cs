using ReactiveUI;
using System.Security.AccessControl;

namespace LabWorkGPT1.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _rightLogin = "111";
        private string _rightPassword = "222";
        private string _username;
        private string _password;

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

        public bool CanLogin => _canLogin.Value;

        public LoginViewModel()
        {
            this.WhenAnyValue(x => x.Username, x => x.Password,
                              (user, pass) => !string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(pass))
                .ToProperty(this, x => x.CanLogin, out _canLogin);
        }
    }
}

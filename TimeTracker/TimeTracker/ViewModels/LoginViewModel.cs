using System.Diagnostics;
using System.Windows.Input;
using TimeTracker.Services.Account;
using TinyIoC.Base;
using TinyIoC.Navigation;
using Xamarin.Forms;

namespace TimeTracker.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ICommand _signInCommand;
        private INavigationService _navigationService;
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        private IAccountService _accountService;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand SignInCommand
        {
            get => _signInCommand;
            set => SetProperty(ref _signInCommand, value);
        }

        public LoginViewModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            Username = "dd";
            Password = "dd";
            SignInCommand = new Command(async () =>
            {
                Debug.WriteLine("LoginViewModel");
                bool result = await _accountService.LoginAsync(Username, Password);
                if (result)
                {
                    await _navigationService.PushAsync<DashboardViewModel>();
                }
                else
                {
                }
            });
        }
    }
}
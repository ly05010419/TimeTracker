using System;
using TimeTracker.Services;
using TimeTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TimeTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        protected override async void OnStart()
        {
            var navService = ViewModelLocator.Resolve<INavigationService>();
            await navService.NavigateToAsync<LoginViewModel>();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
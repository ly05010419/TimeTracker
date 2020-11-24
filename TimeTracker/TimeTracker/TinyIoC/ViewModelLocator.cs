using System;
using System.Collections.Generic;
using TimeTracker.Services.Account;
using TimerTracker.Views;
using TimeTracker.ViewModels;
using TimeTracker.Views;
using TinyIoC.Base;
using TinyIoC.Navigation;
using Xamarin.Forms;


namespace TinyIoC
{
    public class ViewModelLocator
    {
        private static TinyIoCContainer  _container;
        private static Dictionary<Type, Type> _viewLookup;
        
        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            Register<LoginViewModel,LoginView>();
            Register<DashboardViewModel,DashboardView>();
            Register<ProfileViewModel,ProfileView>();
            Register<SettingsViewModel,SettingsView>();
            Register<SummaryViewModel,SummaryView>();
            
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IAccountService, AccountService>();
        }

        static void Register<ViewModel, View>() where ViewModel : ViewModelBase where View : Page
        {
            _viewLookup.Add(typeof(ViewModel),typeof(View));
            _container.Register<ViewModel>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type viewModelType)
        {
            var viewType = _viewLookup[viewModelType];
            var page = (Page) Activator.CreateInstance(viewType);
            var pageModel = _container.Resolve(viewModelType);
            page.BindingContext = pageModel;
            return page;
        }
    }
}
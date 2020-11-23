﻿using System.Threading.Tasks;
using TimeTracker.ViewModels;
 using TimeTracker;
 using Xamarin.Forms;

namespace TimeTracker.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync<ViewModel>(object navigationData = null, bool setRoot = false)  where ViewModel:ViewModelBase
        {
            var page = ViewModelLocator.CreatePageFor(typeof(ViewModel));
            if (setRoot)
            {
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = tabbedPage;
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }
            else
            {
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = tabbedPage;
                }
                else if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }

            if (page.BindingContext is ViewModelBase vmBase)
            {
                await vmBase.InitializeAsync(navigationData);
            }
        }

        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
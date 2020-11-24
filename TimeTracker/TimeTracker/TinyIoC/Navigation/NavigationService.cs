using System.Threading.Tasks;
using TimeTracker;
using TinyIoC.Base;
using Xamarin.Forms;

namespace TinyIoC.Navigation
{
    public class NavigationService : INavigationService
    {
        public async Task PushAsync<ViewModel>(bool setRoot = false)  where ViewModel:ViewModelBase
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
                await vmBase.InitAsync();
            }
        }

        public Task PopAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
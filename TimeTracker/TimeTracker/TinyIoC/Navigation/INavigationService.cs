using System.Threading.Tasks;
using TinyIoC.Base;

 namespace TinyIoC.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation ethode to push onto the Navigation Stack
        /// </summary>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <typeparam name="ViewModel"></typeparam>
        /// <returns></returns>
        Task PushAsync<ViewModel>( bool setRoot = false) where ViewModel:ViewModelBase;

        /// <summary>
        /// Navigation method to pop off of the Naviation Stack
        /// </summary>
        /// <returns></returns>
        Task PopAsync();
    }
}
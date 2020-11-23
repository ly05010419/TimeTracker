﻿using System.Threading.Tasks;
using TimeTracker.ViewModels;

namespace TimeTracker.Services
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
        Task NavigateToAsync<ViewModel>(object navigationData = null, bool setRoot = false) where ViewModel:ViewModelBase;

        /// <summary>
        /// Navigation method to pop off of the Naviation Stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}